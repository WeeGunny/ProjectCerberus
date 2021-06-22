using UnityEngine.Audio;
using System;
using UnityEngine;

[CreateAssetMenu (fileName = "Audio Manager")]
public class AudioManager : SingletonScriptableObject<AudioManager> {
    public Sound[] sounds;
    public AudioMixerGroup mixerGroup, sfxMixerGroup, musicMixerGroup;
    public static AudioManager audioManager => Instance;
    float pitchEffect;

    public void Play(string name, GameObject emitObject) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) {
            Debug.LogWarning("Sound: " + name + "not found!");
            return;
        }

        if (!PauseMenu.GamePaused) {

            if (s.soundType == Sound.SoundType.SFX) {
                PlaySFX(s, emitObject);
            }
            if (s.soundType == Sound.SoundType.Music) {
                PlayMusic(s, emitObject);
            }


        }
    }

    private void PlaySFX(Sound s, GameObject emitObject) {
        s.source = DetermineAudioSource(emitObject);
        s.source.outputAudioMixerGroup = sfxMixerGroup;
        s.source.clip = s.clip;
        s.source.Play();

    }

    private void PlayMusic(Sound s, GameObject emitObject) {
        s.source = DetermineAudioSource(emitObject);
        s.source.outputAudioMixerGroup = musicMixerGroup;
        s.source.clip = s.clip;
        s.source.Play();

    }

    AudioSource DetermineAudioSource (GameObject emitObject) {
        AudioSource source = (emitObject.GetComponent<AudioSource>() == null) ? emitObject.AddComponent<AudioSource>() : emitObject.GetComponent<AudioSource>();
        return source;
        }

    public void Stop(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) {
            Debug.LogWarning("Sound: " + name + "not found!");
            return;
        }
        s.source.Stop();
    }

    public void GritEffect() {
        if (!PlayerStats.Instance) return;
        if(PlayerStats.Instance.GritActive && pitchEffect>=0.5f) {
            pitchEffect -= Time.deltaTime * 2 / Time.timeScale;
            mixerGroup.audioMixer.SetFloat("MasterPitch", pitchEffect);
        }

        if(!PlayerStats.Instance.GritActive && pitchEffect<1) {
            pitchEffect += Time.deltaTime * 2 / Time.timeScale;
            mixerGroup.audioMixer.SetFloat("MasterPitch", pitchEffect);
        }
    }
}
