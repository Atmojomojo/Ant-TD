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
    public AudioMixer music;
    public AudioMixer sfx;
    public AudioMixer allsounds;

    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 0.8f);
        }

        if (!PlayerPrefs.HasKey("sfxVolume"))
        {
            PlayerPrefs.SetFloat("sfxVolume", 0.8f);
        }

        if (!PlayerPrefs.HasKey("allsoundsVolume"))
        {
            PlayerPrefs.SetFloat("allsoundsVolume", 0.8f);
        }
        Load();
    }

    public void SetSFXSlider(float newVolume)
    {
        sfx.SetFloat("Volume", Mathf.Log10(newVolume) * 20);
        PlayerPrefs.SetFloat("sfxVolume", sfxSlider.value);
    }

    public void SetMusicSlider(float newVolume)
    {
        music.SetFloat("Volume", Mathf.Log10(newVolume) * 20);
        PlayerPrefs.SetFloat("musicVolume", musicSlider.value);
    }
    public void SetallsoundsSlider(float newVolume)
    {
        allsounds.SetFloat("Volume", Mathf.Log10(newVolume) * 20);
        PlayerPrefs.SetFloat("allsoundsVolume", allsoundsSlider.value);
    }

    private void Load()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        allsoundsSlider.value = PlayerPrefs.GetFloat("allsoundsVolume");
        Debug.Log(PlayerPrefs.GetFloat("Volume"));

    }
}
