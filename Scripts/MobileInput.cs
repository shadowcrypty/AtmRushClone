using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInput 
{
    private float _vertical;
    private float _horizontal;
    public float Vertical
    {
        get
        {
            ScreenInput();

            return _vertical;
        }
    }
    public float Horizontal
    {
        get
        {
            ScreenInput();
            return _horizontal;
        }
    }


    void ScreenInput()
    {
        _vertical = Input.GetTouch(0).deltaPosition.y;
        _horizontal = Input.GetTouch(0).deltaPosition.x;
    }


}
