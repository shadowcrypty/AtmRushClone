using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class ClampObjectPosition 
{

    public void Clamp(GameObject clampobject,Vector3 LeftBottomBackCorner,Vector3 RightUpFrontCorner)
    {
        Rigidbody rigidbody = clampobject.GetComponent<Rigidbody>();
        rigidbody.MovePosition(new Vector3( Mathf.Clamp(rigidbody.position.x,LeftBottomBackCorner.x,RightUpFrontCorner.x), Mathf.Clamp(rigidbody.position.y, LeftBottomBackCorner.y, RightUpFrontCorner.y), Mathf.Clamp(rigidbody.position.z, LeftBottomBackCorner.z, RightUpFrontCorner.z)));
    }

    
}
