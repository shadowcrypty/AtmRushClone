using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Money : MonoBehaviour
{
    public MoneyUpgradeState CState;
    /*
    private IUpgradeable _upgradeable;
    private IDestroyable _destroyable;
    private ICollectable _collectable;*/
    [SerializeField]
    private UnityEvent _destroy,_upgrade,_collect,_drop;

    private void Awake()
    {
        CState = MoneyUpgradeState.normal;/*
        _upgradeable = GetComponent<IUpgradeable>();
        _destroyable = GetComponent<IDestroyable>();
        _collectable = GetComponent<ICollectable>();*/
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Destroyer"))
        {
            _destroy.Invoke();
        }
        if (other.CompareTag("Upgrader"))
        {
            _upgrade.Invoke();
        }
        if (other.CompareTag("Finish"))
        {
            _drop.Invoke();
        }
        if (MoneyCollect.S_Moneys.Contains(transform))
        {
            return;
        }
        if (MoneyCollect.S_Moneys.Contains(other.transform) || other.CompareTag("Player"))
        {
            _collect.Invoke();
        }
        
    }
}
public enum MoneyUpgradeState
{
    normal,gold,rub

}

