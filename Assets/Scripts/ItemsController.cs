using UnityEngine;

public class ItemsController : MonoBehaviour
{
    [SerializeField] private ItemEnum itemName;
    private GameObject audioFXGO;
    private GameObject scoreManagerGO;
    private AudioFX audioFX;
    private ScoreManager scoreManager;
    private GameObject itemGO;
    private PlayerExtras playerExtras;

    private void Awake()
    {
        itemGO = gameObject;
    }

    private void Start()
    {
        audioFXGO = GameObject.Find("AudioFX");
        scoreManagerGO = GameObject.Find("ScoreManager");
        audioFX = audioFXGO.GetComponent<AudioFX>();
        scoreManager = scoreManagerGO.GetComponent<ScoreManager>();
        playerExtras = GameObject.FindWithTag("Player").GetComponent<PlayerExtras>(); ;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        switch (itemName)
        {
            case ItemEnum.Coin:
                scoreManager.CoinsCollected += scoreManager.CoinValue;
                PlayerPrefs.SetInt("CoinsScore", scoreManager.CoinsCollected);
                scoreManager.UpdateScore();
                audioFX.PlayFX(AudioFX.AudioClipName.Coin);
                itemGO.SetActive(false);
                break;
            case ItemEnum.DoubleJump:
                audioFX.PlayFX(AudioFX.AudioClipName.DoubleJump);
                itemGO.SetActive(false);
                playerExtras.IsDoubleJumpEnable = true;
                break;

        }
    }
}
