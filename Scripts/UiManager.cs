using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoSingleton<UiManager>
{
   
    public GameObject gameend,winscreen, losescreen;
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
