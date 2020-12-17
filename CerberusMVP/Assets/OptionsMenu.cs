using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetVolumeMaster(float MasterVolume)
    {
        audioMixer.SetFloat("MasterVolume", MasterVolume);
    }

    public void SetVolumeMusic(float MusicVolume)
    {
        audioMixer.SetFloat("MusicVolume", MusicVolume);
    }

    public void SetVolumeSFX(float SFXVolume)
    {
        audioMixer.SetFloat("SFXVolume", SFXVolume);
    }
}
