using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
   
    public enum GameStatus
    { failed, win, playing }
    public static  GameStatus State=GameStatus.playing;
    private int GameLevel = 0;
    public GameObject player;
    int size;
   
    void Update()
    {
        if (State ==GameStatus.win)
        {
            //win condition
            Win();
        }
        else if (State == GameStatus.failed)
        {
            //lose condition
            Lose();
        }

    }

    public void Win()
    {
        UiManager.Instance.WinUi();
    }
    public void Lose()
    {
        UiManager.Instance.LoseUi();
    }
    
    

   

}
