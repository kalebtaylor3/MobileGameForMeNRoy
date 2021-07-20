using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostFXControl : MonoBehaviour
{
    private PostProcessVolume volume;
    private Bloom _bloom;
    private ColorGrading _colorgraiding;
    private LensDistortion _lensdistort;
    private ChromaticAberration _chromeatic;

    private void Start()
    {
        volume = GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out _bloom);
        volume.profile.TryGetSettings(out _colorgraiding);
        volume.profile.TryGetSettings(out _lensdistort);
        volume.profile.TryGetSettings(out _chromeatic);
    }

    void ApplyEffects(bool canApply)
    {
        if(canApply)
        {
            _chromeatic.intensity.value = Mathf.Lerp(_chromeatic.intensity.value, 1, 0.5f);
            _bloom.intensity.value = 17f;
        }
    }

    void ResetEffects()
    {
        _bloom.intensity.value = 9.63f;
        _chromeatic.intensity.value = 0.264f;
    }

    // Start is called before the first frame update
    private void OnEnable()
    {
        PlayerControl.OnDrag += ApplyEffects;
        PlayerControl.OnEndDrag += ResetEffects;
    }

    private void OnDisable()
    {
        
    }
}
