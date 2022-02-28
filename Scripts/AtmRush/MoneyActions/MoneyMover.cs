using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyMover : MonoBehaviour
{
    private IMoveable _moveable;
    [SerializeField]
    private Transform player;
    private void Awake()
    {
        _moveable = new MoneyListMover();
    }
    private void LateUpdate()
    {
        if (GameManager.Instance.State == GameManager.GameStatus.playing)
        {
            _moveable.Move(player);
        }
        
    }
}
