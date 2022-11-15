using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioMixer _audioMixer;

    AudioSource _audioSource;

    [SerializeField] AudioClip buttonClick;
    [SerializeField] AudioClip buyButtonClick;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        ButtonSessions.buttonClicked += ButtonClickSound;
        WalletController.boughtButton2 += BuyButtonSound;
        WalletController.boughtButton3 += BuyButtonSound;
    }

    void BuyButtonSound()
    {
        _audioSource.PlayOneShot(buyButtonClick);
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
        WalletController.boughtButton2 -= BuyButtonSound;
        WalletController.boughtButton3 -= BuyButtonSound;
    }
}
