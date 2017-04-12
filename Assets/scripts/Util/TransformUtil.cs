using System;
using System.Collections.Generic;
using UnityEngine;

public static class TransformUtil
{
    public static void LookAt2D(this Transform self, Vector3 point)
    {
        point.y = self.position.y;
        self.LookAt(point);
    }
}
