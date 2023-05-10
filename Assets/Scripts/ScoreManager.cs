using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] Text scoreText;

    private int _coinsCollected;
    private float _distanceTraveled;
    private int _coinValue = 5;

    public int CoinsCollected { get => _coinsCollected; set => _coinsCollected = value; }
    public float DistanceTraveled { get => _distanceTraveled; set => _distanceTraveled = value; }
    public int CoinValue { get => _coinValue; }

    //private void Awake()
    //{
    //    DontDestroyOnLoad(gameObject);
    //}

    public void UpdateScore()
    {
        scoreText.text = "Score: " + PlayerPrefs.GetInt("CoinsScore");
    }

}
