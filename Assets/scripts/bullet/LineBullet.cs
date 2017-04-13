using UnityEngine;
using System.Collections;
using System;

public class LineBullet : BaseBullet,IMovement
{
    private bool beginToMove;
    protected override void OnLoad()
    {
        base.OnLoad();
    }

    protected override void OnUpdate(float deltaTime)
    {
        if(beginToMove)
        {
            transform.position += transform.rotation * Vector3.forward * speed * Time.deltaTime;
        }
    }

    public void Move(Vector3 bornPos, Quaternion moveDir)
    {
        transform.position = bornPos;
        transform.rotation = moveDir;
        beginToMove = true;
    }
}
