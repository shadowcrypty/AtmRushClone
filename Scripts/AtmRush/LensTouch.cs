using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LensTouch : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        AtmRush.Instance.UpgradeMe(other.transform,transform);
    }
}
