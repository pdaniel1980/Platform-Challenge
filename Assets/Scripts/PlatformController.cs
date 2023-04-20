using UnityEngine;

public class PlatformController : MonoBehaviour
{
    PlatformManager platformManager;
    GameObject platformGO;

    private void Awake()
    {
        platformGO = gameObject;
    }

    private void Start()
    {
        platformManager = GameObject.FindObjectOfType<PlatformManager>();
    }

    private void Update()
    {
        platformGO.transform.Translate(platformManager.Speed * Time.deltaTime * Vector2.left);
    }
}
