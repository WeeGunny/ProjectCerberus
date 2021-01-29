using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;
    public enum SoundType {Music,SFX,Default};
    public SoundType soundType = SoundType.SFX;
[HideInInspector] public AudioSource source;
}
    
