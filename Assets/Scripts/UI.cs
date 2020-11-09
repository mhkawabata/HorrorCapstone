using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class UI : MonoBehaviour
{
    #region Singleton
    public static UI instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
    
    //death panel stuff
    [SerializeField] private GameObject deathPanelStuff = null;
    [SerializeField] private Animator deathPanelAnim = null;

    //options stuff
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    public Dropdown qualityDropdown;
    public Dropdown textureDropdown;
    //public Dropdown antiAliasDropdown;
    public Slider volumeSlider;
    float currentVolume;
    Resolution[] resolutions;

    private void Start()
    {
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;

        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;
        }

        //resolutionDropdown.AddOptions(options);
        //resolutionDropdown.RefreshShownValue();
        //LoadSettings(currentResolutionIndex);
    }

    public void Restart(){
//restart
        SceneManager.LoadScene(1);
    }

    public void ExitGame(){
//quit
        Application.Quit();
    }
    public void Die(){
//die
        deathPanelAnim.SetBool("isDead", true);
        deathPanelStuff.SetActive(true);
    }
   
//    public void SetVolume(float volume){
////set volume
//        audioMixer.SetFloat("Volume", volume);
//        currentVolume = volume;
//    }

//    public void SetFullscreen(bool isFullscreen){
////set fullscreen
//        Screen.fullScreen = isFullscreen;
//    }

//    public void SetResolution(int resolutionIndex){
////set resolution
//        Resolution resolution = resolutions[resolutionIndex];
//        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
//    }

//    public void SetTextureQuality(Dropdown tdd){
////set texture quality
//        QualitySettings.masterTextureLimit = tdd.value;
//        qualityDropdown.value = 6;
//    }

    //public void SetAntiAliasing(Dropdown aadd) {

    //    QualitySettings.antiAliasing = aadd.value;
    //    qualityDropdown.value = 6;
    //}

    //public void SaveSettings()
    //{
    //    PlayerPrefs.SetInt("QualitySettingPreference", qualityDropdown.value);
    //    PlayerPrefs.SetInt("ResolutionPreference", resolutionDropdown.value);
    //    PlayerPrefs.SetInt("TextureQualityPreference", textureDropdown.value);
    //    //PlayerPrefs.SetInt("AntiAliasingPreference", antiAliasDropdown.value);
    //    PlayerPrefs.SetInt("FullscreebPreference", Convert.ToInt32(Screen.fullScreen));
    //    PlayerPrefs.SetFloat("VolumePreference", currentVolume);
    //}

    //public void LoadSettings(int currentResolutionIndex)
    //{
    //    //qualityDropdown.value = 3;
    //    resolutionDropdown.value = currentResolutionIndex;
    //    textureDropdown.value = 0;
    //    //antiAliasDropdown.value = 1;
    //    Screen.fullScreen = true;
    //    volumeSlider.value = PlayerPrefs.GetFloat("VolumePreference");
    //}
}
