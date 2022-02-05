using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner 
{
    public void MoveForward(GameObject player,float velocity_z)
    {
        Rigidbody _rb=player.GetComponent<Rigidbody>();
        _rb.velocity = new Vector3(_rb.velocity.x, _rb.velocity.y, velocity_z);
    }
    public void MoveHorizontal(GameObject player,float delta_x)
    {
        Rigidbody _rb = player.GetComponent<Rigidbody>();
        _rb.MovePosition(_rb.position+new Vector3(delta_x,0,0));
    }
}
