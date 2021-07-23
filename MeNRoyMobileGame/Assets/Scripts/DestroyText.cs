using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyText : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}
