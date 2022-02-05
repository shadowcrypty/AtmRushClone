using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public  class AtmRush :MonoBehaviour
{
    private static AtmRush _instance;
    public static AtmRush Instance { get {
            if (_instance == null)
            {
                _instance = new AtmRush();
                return _instance;

            }
            return _instance; } }

    private void OnEnable()
    {
        _instance = this;
        moneys = new List<Transform>();
    }
    public List<Transform> moneys;
    public GameObject player,gold,rub,fx;
    public Material Mgold,Mrub;
    public static int ValueOfCart;
    
    public void MoveInListObjects(List<Transform> TransformList ,GameObject player)
    {
        for (int i = 0; i < TransformList.Count; i++)
        {
            if (i == 0)
            {
                TransformList[i].position = player.transform.position + Vector3.forward;
            }
            else
            {
                TransformList[i].DOLocalMove(TransformList[i - 1].position + Vector3.forward, 0.25f);
            }

        }
    }

    public void AddMoney(List<Transform> TransformList, Transform _money)
    {
        if (TransformList.Contains(_money))
        {
            return;
        }
        TransformList.Add(_money);
        ShockAnimation(TransformList);
    }
    public async Task ShockAnimation(List<Transform> TransformList)
    {
        for (int k = TransformList.Count - 1; k > 0; k--)
        {
            int m = k;
            TransformList[m].DOScale(Vector3.one * 1.5f, 0.1f).OnComplete(() => TransformList[m].DOScale(Vector3.one, 0.1f));
            await Task.Delay(50);
        }
    }

    public void SeperateList(Transform hit)
    {
        for (int i = moneys.Count-1; i >=0 ; i--)
        {
            var outed = moneys[i];
            moneys.Remove(outed);

            if (hit==outed)
            {
                //destroy animation
                // opening fx
                GameObject _fx = Instantiate(fx);
                _fx.transform.position = outed.transform.position;
                Destroy(_fx,0.5f);

                outed.gameObject.SetActive(false);
                break;
            }
            else
            {
                ThrowMe(outed);
            }

        }
        
    }

    public void UpgradeMe(Transform me,Transform upgrader)
    {
        if (moneys.Contains(me))
        {
            switch (me.tag)
            {
                case "money":

                    me.tag = "gold";
                    me.GetComponent<Renderer>().material = Mgold;
                    /*GameObject upgrade = Instantiate(gold,me.parent,true);
                    upgrade.transform.position = me.position;
                    moneys.Add(upgrade.transform);
                    moneys.Remove(me);
                    me.gameObject.SetActive(false);
                    //load gold*/
                    
                    break;
                case"gold":
                    me.tag = "rub";
                    me.GetComponent<Renderer>().material = Mrub;
                    break;

                default:
                    break;
            }

        }

    }

    public void Finish(Transform hit)
    {
        
        player.tag = "Untagged";
        if (moneys.Contains(hit))
        {

            hit.GetComponent<BoxCollider>().enabled = false;
            moneys.Remove(hit);
            MoneyCounter(hit);
            
            hit.DOMoveX(-3,1f);

        }
        else
        {
            //gameend
            InputManager.Instance.forwardSpeed = 0;
            A_MoneyElevator();
        }
    }

    public void A_MoneyElevator()
    {

        player.transform.DOLocalMoveY(ValueOfCart,ValueOfCart*0.1f).SetEase(Ease.Linear).OnComplete(() =>
            GameManager.Instance.State = GameManager.GameStatus.win);


    }

    public void ThrowMe(Transform me)
    {
        var ranx = UnityEngine.Random.Range(-2.7f, 2.7f);
        var ranz = UnityEngine.Random.Range(me.position.z +10, me.position.z +15);
        Vector3 vRandom = new Vector3(ranx, 0, ranz);
        me.DOLocalMove(vRandom, 0.26f);
        me.DOScale(Vector3.one,0.2f);
        
    }
     
    public void MoneyCounter(Transform hit)
    {
        //ValueOfCart = 0;
        
            switch (hit.tag)
            {
                case "money":
                    ValueOfCart += 1;
                    break;
                case "gold":
                    ValueOfCart += 2;
                    break;
                case "rub":
                    ValueOfCart += 4;
                    break;
                default:
                    break;
            }
    }
    private void LateUpdate()
    {
        if (GameManager.Instance.State == GameManager.GameStatus.playing)
        {
            MoveInListObjects(moneys, player);

        }
    }
}
