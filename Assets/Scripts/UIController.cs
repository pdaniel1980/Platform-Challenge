using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Text coinsCollectedText;
    GameObject scoreManagerGO;

    private void Start()
    {
        scoreManagerGO = GameObject.Find("ScoreManager");
        coinsCollectedText.text += scoreManagerGO.GetComponent<ScoreManager>().CoinsCollected.ToString();
    }

    public void RetryGame()
    {
        SceneManager.LoadScene("LevelScene");
    }
}
