using UnityEngine;

public class LimitController : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    private GameObject limitGO;

    private void Awake()
    {
        limitGO = gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.GameOver();
        }
    }
}
