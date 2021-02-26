using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class OptionsMenu : MonoBehaviour {
    public AudioMixer audioMixer;

    public TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;
    public TMP_Dropdown qualityLevelDropDown;

    void Start() {
            SetupResolutionList();
            SetupQualityList();        
    }

    private void SetupResolutionList() {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++) {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height) {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.RefreshShownValue();
        resolutionDropdown.value = currentResolutionIndex;   
    }

    private void SetupQualityList() {
        List<string> qualityLevels = new List<string>();
        qualityLevelDropDown.ClearOptions();
        for(int i = 0; i < QualitySettings.names.Length; i++) {
            qualityLevels.Add(QualitySettings.names[i]);
        }
        qualityLevelDropDown.AddOptions(qualityLevels);
        qualityLevelDropDown.value = QualitySettings.GetQualityLevel();
        qualityLevelDropDown.RefreshShownValue();

    }

    public void SetResolution(int resolutionIndex) {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SetQuality(int qualityIndex) {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetVolumeMaster(float MasterVolume) {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(MasterVolume) * 20);
    }

    public void SetVolumeMusic(float MusicVolume) {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(MusicVolume) * 20);
    }

    public void SetVolumeSFX(float SFXVolume) {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(SFXVolume) * 20);
    }



    public void SetFullscreen(bool isFullscreen) {
        if (isFullscreen) Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        else Screen.fullScreenMode = FullScreenMode.Windowed;
    }

    public void SetCamSensitivity(float CamSensitivtity) {
        rbCam.sensitivity = CamSensitivtity;
    }
}
