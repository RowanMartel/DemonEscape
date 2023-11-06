using UnityEngine;

public class VolumeChanger : MonoBehaviour
{
    [SerializeField] bool isBGM;
    VolumeManager volumeManager;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        volumeManager = Singleton.Instance.GetComponentInChildren<VolumeManager>();
        if (isBGM)
        {
            volumeManager.BGMVolChanged += ChangeVolume;
            audioSource.volume = volumeManager.BGMVol;
        }
        else
        {
            volumeManager.SFXVolChanged += ChangeVolume;
            audioSource.volume = volumeManager.SFXVol;
        }
    }

    void ChangeVolume(object source, SetVolEventArgs volume)
    {
        audioSource.volume = volume.value;
    }
}// I don't think this class actually does anything