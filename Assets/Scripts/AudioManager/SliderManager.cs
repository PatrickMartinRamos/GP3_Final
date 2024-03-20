using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; set; }
    public AudioSource audioSource;
    public Volumes bgm;
    public Slider bgm_slider;

    private void Awake()
    {
        if (instance != null && instance != this) { Destroy(this); }
        else { instance = this; }

        bgm.volume = audioSource.volume;
        bgm_slider.value = bgm.volume;

    }

    private void Update()
    {
        audioSource.volume = bgm.volume;
    }

    public void ChangeBGMVolume()
    {
        bgm.volume = bgm_slider.value;
        audioSource.volume = bgm.volume;
    }

}