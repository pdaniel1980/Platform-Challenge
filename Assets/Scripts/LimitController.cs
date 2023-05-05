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

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    //Debug.Log("GO: " + collision.name);
    //    if (collision.CompareTag("Platform") && limitGO.name == "LeftLimit")
    //    {
    //        //Debug.Log("Salimossss: " + collision.name);
    //        //Destroy(collision.gameObject);
    //        collision.gameObject.SetActive(false);
    //    }
        
    //}
}
