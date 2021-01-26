using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;
    public enum SoundType {Music,SFX,Default};
    public SoundType soundType = SoundType.SFX;

    //[Range(0f, 1f)]
    //public float volume;

    //[Range(0.1f, 3f)]
    //public float pitch;

    //public bool loop;

    //[HideInInspector]
    public AudioSource source;
}
    
