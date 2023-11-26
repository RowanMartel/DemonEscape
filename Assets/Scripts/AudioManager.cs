using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public float BGMVol;
    public float SFXVol;

    [SerializeField] Slider BGMSlider;
    [SerializeField] Slider SFXSlider;

    [SerializeField] AudioSource BGMSource;

    public enum BGMEnum
    {
        title,
        menus,
        gameplay1,
        gameplay2,
        credits
    }
    [SerializeField] AudioClip titleBGM;
    [SerializeField] AudioClip menusBGM;
    [SerializeField] AudioClip gameplay1BGM;
    [SerializeField] AudioClip gameplay2BGM;
    [SerializeField] AudioClip creditsBGM;

    void SetBGMVol()
    {
        BGMVol = BGMSlider.value;
        BGMSource.volume = BGMVol;
    }
    void SetSFXVol()
    {
        SFXVol = SFXSlider.value;
    }

    public void SetBGM(BGMEnum BGM)
    {
        BGMSource.Stop();
        AudioClip clipToPlay = titleBGM;
        switch (BGM)
        {
            case BGMEnum.title:
                clipToPlay = titleBGM;
                break;
            case BGMEnum.menus:
                clipToPlay = menusBGM;
                break;
            case BGMEnum.gameplay1:
                clipToPlay = gameplay1BGM;
                break;
            case BGMEnum.gameplay2:
                clipToPlay = gameplay2BGM;
                break;
            case BGMEnum.credits:
                clipToPlay = creditsBGM;
                break;
        }
        BGMSource.PlayOneShot(clipToPlay);
    }

    private void Update()
    {
        SetBGMVol();
        SetSFXVol();
    }
}