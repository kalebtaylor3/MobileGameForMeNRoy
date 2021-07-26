using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Fade : MonoBehaviour
{

    private CanvasGroup groupcanv;

    private void OnEnable()
    {
        groupcanv = GetComponent<CanvasGroup>();
        groupcanv.alpha = Mathf.Lerp(groupcanv.alpha, 1, 0.001f);
    }
}
