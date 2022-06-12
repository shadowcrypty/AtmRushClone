using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LensTouch : MonoBehaviour
{
    
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IUpgradeable upgradeable))
        {
            upgradeable.Upgrade();
        }
    }
}
