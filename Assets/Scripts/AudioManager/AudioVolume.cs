using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmVolume : MonoBehaviour
{
    AudioSource bgmSource;
    public Volumes audio;

    private void Awake()
    {
        bgmSource = GetComponent<AudioSource>();
        bgmSource.volume = audio.volume;
    }

}