using UnityEngine;

public class AudioFX : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClip;
    AudioSource audioSource;

    public enum AudioClipName {
        AmbienceBase, AmbienceNight, Coin, DoubleJump, GameOverHit, Jump,
        Land, PowerupDoubleJump, PowerupShield, ShieldBreak
    }

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void PlayFX(AudioClipName clip)
    {
        audioSource.clip = audioClip[(int) clip];
        audioSource.volume = 0.8f;
        audioSource.Play();
    }
}
