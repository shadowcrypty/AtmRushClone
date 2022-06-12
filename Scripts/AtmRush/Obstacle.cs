using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDestroyable destroyable))
        {
            destroyable.Destroyer(other.transform);

        }
    }
}
