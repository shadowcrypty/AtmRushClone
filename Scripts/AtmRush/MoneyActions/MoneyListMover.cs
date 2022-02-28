using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyListMover : IMoveable
{
    [SerializeField]
    private Transform player;
    public void Move(Transform Move)
    {
        MoveInListObjects(MoneyCollect.S_Moneys,Move.gameObject);
    }
    public void MoveInListObjects(List<Transform> TransformList, GameObject leadtransform)
    {

        for (int i = 0; i < TransformList.Count; i++)
        {
            if (i == 0)
            {
                TransformList[i].position = leadtransform.transform.position + Vector3.forward;
            }
            else
            {
                TransformList[i].DOLocalMove(TransformList[i - 1].position + Vector3.forward * 2.2f, 0.15f);
            }

        }
    }

}
