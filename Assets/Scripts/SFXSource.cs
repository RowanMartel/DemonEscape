using UnityEngine;

public class SFXSource : MonoBehaviour
{
    AudioSource SFXAudioSource;
    AudioManager audioManager;

    void Start()
    {
        SFXAudioSource = GetComponent<AudioSource>();
        audioManager = Singleton.Instance.GetComponentInChildren<AudioManager>();
    }
    private void Update()
    {
        SFXAudioSource.volume = audioManager.SFXVol;
    }// adjust the volume to match the audio manager
}