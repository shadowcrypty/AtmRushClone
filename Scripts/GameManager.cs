using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }
    public enum GameStatus
    { failed, win, playing }
    

    public GameStatus State;
    private int GameLevel = 0;
    public GameObject player;
    int size;

    private void OnEnable()
    {
        _instance = this;
        _instance.State = GameStatus.playing;
    }
    void Start()
    {

    }

    void Update()
    {
        if (_instance.State ==GameStatus.win)
        {
            //win condition
            Win();
        }
        else if (_instance.State == GameStatus.failed)
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
