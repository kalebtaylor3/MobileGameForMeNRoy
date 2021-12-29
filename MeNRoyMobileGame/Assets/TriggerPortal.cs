using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TriggerPortal : MonoBehaviour
{

    public Animator portalAnimations;
    public GameObject playerInPortal;
    public ParticleSystem enterParticles;

    public static event Action OnPortal;

    private FollowCamera camera;

    int triggerOnce = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerInPortal.SetActive(false);
        enterParticles.Stop();
        camera = GameObject.FindObjectOfType<FollowCamera>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && triggerOnce == 0)
        {
            OnPortal?.Invoke();
            playerInPortal.SetActive(true);
            enterParticles.Play();
            StartCoroutine(waitForParticles());
            StartCoroutine(waitForAnimation());
            camera.SetTarget(2, this.transform);
            triggerOnce = 1;
        }
    }

    IEnumerator waitForParticles()
    {
        yield return new WaitForSeconds(0.8f);
        enterParticles.Stop();
    }

    IEnumerator waitForAnimation()
    {
        yield return new WaitForSeconds(0.1f);
        portalAnimations.SetBool("triggerPortal", true);
    }
}
