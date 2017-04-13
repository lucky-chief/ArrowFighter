using System;
using System.Collections.Generic;
using UnityEngine;

public interface IMovement
{
    void Move(Vector3 bornPos, Quaternion moveDir);
}
