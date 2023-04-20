using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject audioFXGO;
    AudioFX audioFX;

    [SerializeField] AudioClip[] audioClips;
    AudioSource audioSource;

    [SerializeField] GameObject limitGO;

    [SerializeField] PlatformManager platformManager;

    GameObject playerGO;

    private void Start()
    {
        playerGO = GameObject.FindWithTag("Player");
        audioFX = audioFXGO.GetComponent<AudioFX>();
        audioSource = gameObject.GetComponent<AudioSource>();        
        StartGame();
    }

    void StartGame()
    {
        audioSource.clip = audioClips[0];
        audioSource.volume = 0.2f;
        audioSource.Play();
    }

    public void Retry()
    {
        SceneManager.LoadScene("LevelScene");
    }

    public void GameOver()
    {
        StartCoroutine(GameOverCoroutine());        
    }

    IEnumerator GameOverCoroutine()
    {
        audioFX.PlayFX(AudioFX.AudioClipName.GameOverHit);
        platformManager.Stop();
        yield return new WaitForSeconds(2f);

        audioSource.Stop();
        Destroy(playerGO);
        SceneManager.LoadScene("GameOver");
    }

}
