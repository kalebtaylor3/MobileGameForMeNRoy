using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrajectoryRenderer : MonoBehaviour
{
    Vector3 startPos;
    Vector3 endPos;
    Vector3 mousePos;
    Vector3 mouseDir;
    Camera cam;
    LineRenderer lr;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
        cam = Camera.main;
        PlayerControl.OnDrag += DrawLine;
        PlayerControl.OnEndDrag += DisableLine;
    }

    void DrawLine(bool canDraw)
    {
        if(canDraw)
        {

            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            mouseDir = mousePos - gameObject.transform.position;
            mouseDir.z = 0;
            mouseDir = mouseDir.normalized;

            lr.enabled = true;
            startPos = gameObject.transform.position;
            startPos.z = 0;
            lr.SetPosition(0, startPos);
            endPos = mousePos;
            endPos.z = 0;
            lr.SetPosition(1, endPos);
            lr.SetColors(Color.white, Color.white);
        }
    }

    void DisableLine()
    {
        lr.enabled = false;
    }
}
