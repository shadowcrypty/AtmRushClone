using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
    {
        if (AtmRush.Instance.moneys.Contains(transform))
        {
            return;
        }
        if (AtmRush.Instance.moneys.Contains(other.transform) || other.CompareTag("Player"))
        {
            AtmRush.Instance.AddMoney(AtmRush.Instance.moneys,transform);
        }
        
    }
}
