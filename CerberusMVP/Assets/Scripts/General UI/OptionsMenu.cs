using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetVolumeMaster(float MasterVolume)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(MasterVolume)*20);
    }

    public void SetVolumeMusic(float MusicVolume)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(MusicVolume)*20);
    }

    public void SetVolumeSFX(float SFXVolume)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(SFXVolume)*20);
    }
}
