using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioMixer _audioMixer;

    AudioSource _audioSource;

    [SerializeField] AudioClip buttonClick;
    [SerializeField] AudioClip buyButtonClick;
    [SerializeField] AudioClip destroyCollectableSound;
    [SerializeField] AudioClip mainTheme1;
    [SerializeField] AudioClip hitBlock;
    [SerializeField] AudioClip throwSound;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        ButtonSessions.buttonClicked += ButtonClickSound;
        WalletController.boughtButton2 += BuyButtonSound;
        WalletController.boughtButton3 += BuyButtonSound;
        Collectable.hitCollectable += CollectableSoundActivator;
        BallHandler.hitBlock += HitBlockSoundActivator;
        BallHandler.ballIsThrown += ThrowBallSoundActivator;
        InvokeRepeating(nameof(MainThemeSong), 0.1f,19f);
    }
    
    void ThrowBallSoundActivator()
    {
        _audioSource.PlayOneShot(throwSound);
    }
    
    void HitBlockSoundActivator()
    {
        _audioSource.PlayOneShot(hitBlock);
    }
    
    void MainThemeSong()
    {
        _audioSource.PlayOneShot(mainTheme1);
    }

    void CollectableSoundActivator()
    {
        _audioSource.PlayOneShot(destroyCollectableSound);
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
        Collectable.hitCollectable -= CollectableSoundActivator;
        BallHandler.hitBlock -= HitBlockSoundActivator;
        BallHandler.ballIsThrown -= ThrowBallSoundActivator;
    }
}
