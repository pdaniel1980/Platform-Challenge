using UnityEngine;

public class LimitController : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.GameOver();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("GO: " + collision.name);
        Destroy(collision.gameObject);
    }
}
