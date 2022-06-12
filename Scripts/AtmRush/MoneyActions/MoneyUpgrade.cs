using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyUpgrade : MonoBehaviour, IUpgradeable
{
    [SerializeField]
    private Material gold, rub;
    Transform me;

    private void OnEnable()
    {
        me = transform;
    }
    public void Upgrade()
    {
        if (MoneyCollect.S_Moneys == null)
        {
            Debug.Log("null");
            return;
        }
        if (!MoneyCollect.S_Moneys.Contains(me))
        {
            return;
        }
        if (me.GetComponent<Money>().CState == MoneyUpgradeState.rub)
        {
            return;
        }
        Debug.Log("upgrade");
        me.GetComponent<Money>().CState++;
        if (me.GetComponent<Money>().CState==MoneyUpgradeState.gold)
        {
            me.GetComponent<Renderer>().material = gold;
            return;

        }
        me.GetComponent<Renderer>().material = rub;


    }

}
