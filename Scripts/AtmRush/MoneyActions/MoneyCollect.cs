using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MoneyCollect : MonoBehaviour, ICollectable
{
    public static List<Transform> S_Moneys = new List<Transform>();
    private static int s_valueOfCart;

    public void Collect(Transform collectable)
    {
        AddMoney(S_Moneys,collectable);
    }

    public void AddMoney(List<Transform> TransformList, Transform _money)
    {

        if (TransformList.Contains(_money))
        {
            return;
        }
        TransformList.Add(_money);
        ShockAnimation(TransformList);//-> observer a aktarýlýcak

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

    public void Drop(Transform collectable)
    {
        Finish(collectable);
    }
    public void Finish(Transform hit)
    {
        var moneys = S_Moneys;
        
        ///GameManager.Instance.player.tag = "Untagged";//hatalý
        
        if (moneys.Contains(hit))
        {
            hit.GetComponent<BoxCollider>().enabled = false;
            moneys.Remove(hit);
            MoneyCounter(hit);// -> observer a aktarýlýcak
            hit.DOMoveX(-3, 1f);
            Debug.Log("dropped");
        }
        if (moneys.Count==0)
        {
            //gameend
            InputManager.Instance.forwardSpeed = 0;
            A_MoneyElevator();//-> observer a aktarýlýcak
        }
       
    }

    public void A_MoneyElevator()
    {
        GameManager.Instance.player.transform.DOLocalMoveY(s_valueOfCart, s_valueOfCart * 0.1f).SetEase(Ease.Linear).OnComplete(() =>
               GameManager.State = GameManager.GameStatus.win);
    }
    public void MoneyCounter(Transform hit)
    {
        //ValueOfCart = 0;
        switch (hit.GetComponent<Money>().CState)
        {
            case MoneyUpgradeState.normal:
                s_valueOfCart += 1;
                break;
            case MoneyUpgradeState.gold:
                s_valueOfCart += 2;
                break;
            case MoneyUpgradeState.rub:
                s_valueOfCart += 4;
                break;
            default:
                break;
        }
    }
}
