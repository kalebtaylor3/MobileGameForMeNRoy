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

    float _bloomStart;
    float _lensStart;
    float _chromaticStart;

    private void Start()
    {
        volume = GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out _bloom);
        volume.profile.TryGetSettings(out _colorgraiding);
        volume.profile.TryGetSettings(out _lensdistort);
        volume.profile.TryGetSettings(out _chromeatic);
        _bloomStart = _bloom.intensity.value;
        _lensStart = _lensdistort.intensity.value;
        _chromaticStart = _chromeatic.intensity.value;
    }

    void ApplyEffects(bool canApply)
    {
        if(canApply)
        {
            _chromeatic.intensity.value = Mathf.Lerp(_chromeatic.intensity.value, 1, 0.03f);
            _bloom.intensity.value = Mathf.Lerp(_bloom.intensity.value, 17, 0.03f);
            _lensdistort.intensity.value = Mathf.Lerp(_lensdistort.intensity.value, -44, 0.03f);
        }
    }

    void ResetEffects()
    {
        _chromeatic.intensity.value = Mathf.Lerp(_chromeatic.intensity.value, _chromaticStart, 0.5f);
        _bloom.intensity.value = Mathf.Lerp(_bloom.intensity.value, _bloomStart, 0.5f);
        _lensdistort.intensity.value = Mathf.Lerp(_lensdistort.intensity.value, _lensStart, 0.5f);
    }

    // Start is called before the first frame update
    private void OnEnable()
    {
        PlayerControl.OnDrag += ApplyEffects;
        PlayerControl.OnEndDrag += ResetEffects;
        BadShape.OnBadShape += ResetEffects;
    }

    private void OnDisable()
    {
        PlayerControl.OnDrag -= ApplyEffects;
        PlayerControl.OnEndDrag -= ResetEffects;
        BadShape.OnBadShape += ResetEffects;
    }
}
