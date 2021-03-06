using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoSingleton<InputManager>
{
    public GameObject player;
    public float forwardSpeed;
    public ClampObjectPosition clampObject = new ClampObjectPosition();
    public EditorInput editorInput = new EditorInput();
    public MobileInput mobile = new MobileInput();
    public Runner runner = new Runner();
    public Vector3 LeftBottomBackCorner;
    public Vector3 RightUpFrontCorner;

    void Update()
    {

        if (GameManager.State==GameManager.GameStatus.playing)
        {
            runner.MoveForward(player, forwardSpeed);
            //editor input
            runner.MoveHorizontal(player, editorInput.Horizontal);
            //mobile input
           // runner.MoveHorizontal(player, mobile.Horizontal);
            clampObject.Clamp(player, LeftBottomBackCorner, RightUpFrontCorner);
        }
        else
        {
            runner.MoveForward(player, 0);
        }


    }
}
