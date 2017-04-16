using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 子弹发射器
/// </summary>
public class BulletLauncher
{
    private GameObject owner;
    private int emittCount;
    private string bulletSettled;

    public BulletLauncher(GameObject owner)
    {
        this.owner = owner;
    }

    public void ChangeEmittCount(int value)
    {
        emittCount += value;
    }

    public void ChangeBullet(string bulletId)
    {

    }

    public void Fire()
    {

    }
}
