using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public Sound[] sounds;
    public AudioMixerGroup mixerGroup,sfxMixerGroup,musicMixerGroup;
    public static AudioManager audioManager;
    float pitchEffect;

    void Awake() {
        if (audioManager == null) {
            audioManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
            return;
        }
    }

    private void Update() {
        GritEffect();
    }

    public void Play(string name, GameObject emitObject) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) {
            Debug.LogWarning("Sound: " + name + "not found!");
            return;
        }

        if (!PauseMenu.GamePaused) {

            if(s.soundType == Sound.SoundType.SFX) {
                PlaySFX(s,emitObject);
            }
            if (s.soundType == Sound.SoundType.Music) {
                PlayMusic(s,emitObject);
            }

            
        }
    }

    private void PlaySFX(Sound s, GameObject emitObject) {
        if (emitObject.GetComponent<AudioSource>() == null) {
            s.source = emitObject.AddComponent<AudioSource>();
        }
        else {
            s.source = emitObject.GetComponent<AudioSource>();
        }
        s.source.outputAudioMixerGroup =sfxMixerGroup;
        s.source.clip = s.clip;
        s.source.Play();

    }

    private void PlayMusic(Sound s, GameObject emitObject) {

        if (emitObject.GetComponent<AudioSource>() == null) {
            s.source = emitObject.AddComponent<AudioSource>();
        }
        else {
            s.source = emitObject.GetComponent<AudioSource>();

        }
        s.source.outputAudioMixerGroup = musicMixerGroup;
        s.source.clip = s.clip;
        s.source.Play();

    }

    public void Stop(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) {
            Debug.LogWarning("Sound: " + name + "not found!");
            return;
        }
        s.source.Stop();
    }

    void GritEffect() {
        if(PlayerStats.GritActive && pitchEffect>=0.5f) {
            pitchEffect -= Time.deltaTime * 2 / Time.timeScale;
            mixerGroup.audioMixer.SetFloat("MasterPitch", pitchEffect);
        }

        if(!PlayerStats.GritActive && pitchEffect<1) {
            pitchEffect += Time.deltaTime * 2 / Time.timeScale;
            mixerGroup.audioMixer.SetFloat("MasterPitch", pitchEffect);
        }
    }
}
