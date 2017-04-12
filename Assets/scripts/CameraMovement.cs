using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
    public Transform target;
    public float height ;

    private Vector3 offset;
	// Use this for initialization
	void Start () {
        transform.position = target.position + Vector3.up * height;
        transform.LookAt(target);

        offset = transform.position - target.position;
	}

    void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
