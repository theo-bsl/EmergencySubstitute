using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{

    public Slider slider;
    public AudioMixer mixer;

    private void Start()
    {
        SetVolume(PlayerPrefs.GetFloat("Sound", 50));
    }

    public void SetVolume(float volume)
    {
        if(volume < 1)
        {
            volume = .001f;
        }

        RefreshSlider(volume);
        PlayerPrefs.SetFloat("Sound", volume);
        mixer.SetFloat("Volume", Mathf.Log10(volume / 100) * 20f);
    }

    public void RefreshSlider(float volume)
    {
        slider.value = volume;
    }

    public void ValueChanged()
    {
        SetVolume(slider.value);
    }
}
