using DG.Tweening;
using UnityEngine;

public class MoneyDestroy : MonoBehaviour,IDestroyable
{

    [SerializeField]
    private GameObject _destroyFx;
    public void Destroyer(Transform destroy)
    {
        if (MoneyCollect.S_Moneys.Contains(destroy))
        {
            SeperateList(destroy);

        }
    }

    private void SeperateList(Transform hit)
    {
        var moneys = MoneyCollect.S_Moneys;
        for (int i = moneys.Count - 1; i >= 0; i--)
        {
            var outed = moneys[i];
            moneys.Remove(outed);

            if (hit == outed)
            {
                //destroy animation
                // opening fx
                var _fx=Instantiate(_destroyFx);
                _fx.transform.position = outed.transform.position;
                Destroy(_fx, 0.5f);
                outed.gameObject.SetActive(false);
                break;
            }
            else
            {
                //Throwing upshift part off list members front off player
                ThrowMe(outed);
            }

        }

    }
    private void ThrowMe(Transform me)
    {
        var ranx = UnityEngine.Random.Range(-2.7f, 2.7f);
        var ranz = UnityEngine.Random.Range(me.position.z + 10, me.position.z + 15);
        Vector3 vRandom = new Vector3(ranx, 0, ranz);
        me.DOLocalMove(vRandom, 0.26f);
        me.DOScale(Vector3.one, 0.2f);

    }
}
