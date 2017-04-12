﻿using UnityEngine;
using System.Collections;

public class RoleController : MonoBehaviour
{
    IInputControl inputCtrl;
    CharacterController chCtrl;

    RoleAttribute attributes;
    public RoleAttribute Attributes
    {
        get { return attributes; }
    }

    // Use this for initialization
    void Start()
    {
        inputCtrl = Camera.main.GetComponent<IInputControl>();
        inputCtrl.onMove += OnMove;
        inputCtrl.onFire += OnFire;
        chCtrl = GetComponent<CharacterController>();
    }

    void OnDisable()
    {
        inputCtrl.onMove -= OnMove;
        inputCtrl.onFire -= OnFire;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMove(Vector3 dir)
    {
        chCtrl.SimpleMove(dir.normalized * 5);
    }

    void OnFire(Vector3 screenPoint)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPoint);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1 << LayerMask.NameToLayer("Ground")))
        {
            transform.LookAt2D(hit.point);
        }
    }
}
