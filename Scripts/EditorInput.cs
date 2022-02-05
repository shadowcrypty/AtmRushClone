using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorInput
//This script using for manipulate player during game programming.
{
    private float _vertical;
    private float _horizontal;
    public float Vertical
    {
        get {
            mouseInput();

            return _vertical; }
    }
    public float Horizontal
    {
        get {
            mouseInput();
            return _horizontal; }
    }


    void mouseInput()
    {
        _vertical = Input.GetAxis("Mouse Y");
        _horizontal = Input.GetAxis("Mouse X");
    }
}
