using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int _coinsCollected;
    private float _distanceTraveled;

    public int CoinsCollected { get => _coinsCollected; set => _coinsCollected = value; }
    public float DistanceTraveled { get => _distanceTraveled; set => _distanceTraveled = value; }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

}
