using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioMixer _audioMixer;

    AudioSource _audioSource;

    [SerializeField] AudioClip buttonClick;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        ButtonSessions.buttonClicked += ButtonClickSound;
    }

    void ButtonClickSound()
    {
        _audioSource.PlayOneShot(buttonClick);
    }

    public void SetVolume(float volume)
    {
        _audioMixer.SetFloat("volume", volume);
    }

    void OnDisable()
    {
        ButtonSessions.buttonClicked -= ButtonClickSound;
    }
}
