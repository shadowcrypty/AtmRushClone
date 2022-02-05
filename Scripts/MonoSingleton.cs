using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T:MonoSingleton<T>
{
    private MonoSingleton<T> _instance;
    public MonoSingleton<T> Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectsOfType(typeof(T)) as T;
            }
            return _instance;
        }
    }

    private void OnEnable()
    {
        _instance = this;
    }
}
