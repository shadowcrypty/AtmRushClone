using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    private static UiManager _instance;
    public static UiManager Instance { get { return _instance; } }


    public GameObject gameend,winscreen, losescreen;
    private void OnEnable()
    {
        _instance = this;
    }
    public void WinUi()
    {
        gameend.SetActive(true);
        winscreen.SetActive(true);
    }
    public void LoseUi()
    {
        gameend.SetActive(true);
        losescreen.SetActive(true);
    }


}
