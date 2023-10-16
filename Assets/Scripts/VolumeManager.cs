using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public event EventHandler<SetVolEventArgs> SFXVolChanged;
    public event EventHandler<SetVolEventArgs> BGMVolChanged;

    [SerializeField] Slider SFXSlider;
    [SerializeField] Slider BGMSlider;

    public float SFXVol;
    public float BGMVol;

    void Start()
    {
        SFXSlider.value = Constants.startingSFXVol;
        BGMSlider.value = Constants.startingBGMVol;
        SetSFXVol();
        SetBGMVol();
    }

    public void SetSFXVol()
    {
        SFXVol = SFXSlider.value;
        if (SFXVolChanged != null)
            SFXVolChanged(this, new SetVolEventArgs(SFXVol));
    }
    public void SetBGMVol()
    {
        BGMVol = BGMSlider.value;
        if (BGMVolChanged != null)
            BGMVolChanged(this, new SetVolEventArgs(BGMVol));
    }
}

public class SetVolEventArgs : EventArgs
{
    public float value;
    public SetVolEventArgs (float value)
    {
        this.value = value;
    }
}