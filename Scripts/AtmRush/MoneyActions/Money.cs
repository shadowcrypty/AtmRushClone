using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Money : MonoBehaviour
{
    public MoneyUpgradeState CState;
    //[SerializeField]
    private UnityEvent _collect;

    private void Awake()
    {
        CState = MoneyUpgradeState.normal;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (MoneyCollect.S_Moneys.Contains(transform))
        {
            return;
        }
        if (MoneyCollect.S_Moneys.Contains(other.transform) || other.CompareTag("Player"))
        {
            GetComponent<ICollectable>().Collect(transform);
        }
        
    }
}
public enum MoneyUpgradeState
{
    normal,gold,rub

}

