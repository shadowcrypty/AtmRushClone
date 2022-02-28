using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LensTouch : MonoBehaviour
{
    private IUpgradeable upgradeable;
    
    void Awake()
    {
        upgradeable = GetComponent<IUpgradeable>();
    }
    private void OnTriggerEnter(Collider other)
    {
        //AtmRush.Instance.UpgradeMe(other.transform,transform);
        //upgradeable.Upgrade(other.transform);
        

    }
}
