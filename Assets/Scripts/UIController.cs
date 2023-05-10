using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Text coinsCollectedText;
    GameObject scoreManagerGO;

    private void Start()
    {
        //scoreManagerGO = GameObject.Find("ScoreManager");
        //coinsCollectedText.text = scoreManagerGO.GetComponent<ScoreManager>().CoinsCollected.ToString();
        coinsCollectedText.text = PlayerPrefs.GetInt("CoinsScore").ToString();
    }

    public void RetryGame()
    {
        ResetScore();
        SceneManager.LoadScene("LevelScene");
    }

    private void ResetScore()
    {
        PlayerPrefs.SetInt("CoinsScore", 0);
    }
}
