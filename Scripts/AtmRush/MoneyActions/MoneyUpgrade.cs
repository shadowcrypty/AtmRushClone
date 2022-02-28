using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyUpgrade : MonoBehaviour, IUpgradeable
{
    [SerializeField]
    private Material gold, rub;
    public void Upgrade(Transform me)
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
