using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;
    public Slider allsoundsSlider;
    public AudioMixerGroup music;
    public AudioMixerGroup sfx;
    public AudioMixer allsounds;
    

    void Start()
    {
        //if (!PlayerPrefs.HasKey("musicVolume"))
        //{
        //    PlayerPrefs.SetFloat("musicVolume", 0.8f);
        //}

        //if (!PlayerPrefs.HasKey("sfxVolume"))
        //{
        //    PlayerPrefs.SetFloat("sfxVolume", 0.8f);
        //}

        //if (!PlayerPrefs.HasKey("allsoundsVolume"))
        //{
        //    PlayerPrefs.SetFloat("allsoundsVolume", 0.8f);
        //}

        ////Load();
        ///
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        allsoundsSlider.value = PlayerPrefs.GetFloat("allsoundsVolume");
    }

    public void SetSFXSlider(float sliderValue)
    {
        sfx.audioMixer.SetFloat("VolumeSFX",  Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("sfxVolume", sliderValue);
    }

    public void SetMusicSlider(float sliderValue)
    {
        music.audioMixer.SetFloat("VolumeMusic", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("musicVolume", sliderValue);
    }

    public void SetallsoundsSlider(float sliderValue)
    {
        allsounds.SetFloat("VolumeMaster", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("allsoundsVolume", sliderValue);
    }

    //private void Load()
    //{
    //    musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
    //    music.audioMixer.SetFloat("Volume", musicSlider.value);

    //    sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
    //    sfx.audioMixer.SetFloat("Volume", sfxSlider.value);

    //    allsoundsSlider.value = PlayerPrefs.GetFloat("allsoundsVolume");
    //    allsounds.SetFloat("Volume", allsoundsSlider.value);
    //}
}

