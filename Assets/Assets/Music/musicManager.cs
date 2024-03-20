using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicManager : MonoBehaviour
{
    // Reference to the AudioSource component
    private AudioSource audioSource;

    public AudioClip bgMusic;

    public AudioClip buttonSFX;
    public AudioClip playerHitSFX;
    public AudioClip shieldHitSFX;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayBGM();
    }

    public void PlayBGM()
    {
        audioSource.clip = bgMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    // Method to play the button sound effect
    public void PlayButtonSFX()
    {
        audioSource.PlayOneShot(buttonSFX);
    }
    public void playHitPlayerSFX()
    {
        audioSource.PlayOneShot(playerHitSFX);
    }
    public void shieldHitPlayerSFX()
    {
        audioSource.PlayOneShot(shieldHitSFX);
    }
}
