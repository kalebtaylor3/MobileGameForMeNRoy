using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class TrajectoryRenderer : MonoBehaviour
{
    Vector3 startPos;
    Vector3 endPos;
    Vector3 mousePos;
    Vector3 mouseDir;
    Camera cam;
    LineRenderer lr;

    void DrawLine(bool canDraw)
    {
        if (EventSystem.current.IsPointerOverGameObject() == false)
        {
            if (canDraw)
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
            }
        }
    }

    void DisableLine()
    {
        lr.enabled = false;
    }

    private void OnDisable()
    {
        PlayerControl.OnDrag -= DrawLine;
        PlayerControl.OnEndDrag -= DisableLine;
        PauseMenu.OnPause -= DisableLine;
    }

    private void OnEnable()
    {
        lr = GetComponent<LineRenderer>();
        cam = Camera.main;
        PlayerControl.OnDrag += DrawLine;
        PlayerControl.OnEndDrag += DisableLine;
        PauseMenu.OnPause += DisableLine;
    }
}
