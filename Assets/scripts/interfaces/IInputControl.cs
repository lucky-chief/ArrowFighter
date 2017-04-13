using System;

public interface IInputControl {
    event Action<UnityEngine.Vector3> onMove;
    event Action<UnityEngine.Vector3> onRotate;
    event Action onFire;
}
