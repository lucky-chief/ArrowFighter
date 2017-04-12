using UnityEngine;
using System;
using System.Collections;

public class KeyboardInput : MonoBehaviour, IInputControl
{
    public event Action<Vector3> onMove;
    public event Action<UnityEngine.Vector3> onFire;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 v = new Vector3(x, 0, y);
        if (onMove != null)
        {
            onMove.Invoke(v);
        }

        if (onFire != null)
        {
            onFire.Invoke(Input.mousePosition);
        }
    }
}
