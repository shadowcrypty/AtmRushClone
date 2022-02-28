using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public  class AtmRush :MonoBehaviour
{
    private static AtmRush _instance;
    private List<Transform> moneys;
    public static AtmRush Instance { 
        get {
            if (_instance == null)
            {
                _instance = new AtmRush();
                return _instance;
            }
            return _instance; 
        }
    }
    public GameObject player;
    public static int ValueOfCart;
    private void Awake()
    {
        _instance = this;
        moneys = MoneyCollect.S_Moneys;
    }
   
}
