using UnityEngine;

public class PlatformController : MonoBehaviour
{
    PlatformManager platformManager;
    GameObject platformGO;
    float lastPlatformWidth;

    private void Awake()
    {
        platformGO = gameObject;
    }

    private void Start()
    {
        platformManager = GameObject.FindObjectOfType<PlatformManager>();
        CheckPlatformWidth();
        //CheckPlatformWidth();
        //Debug.Log(platformGO.name + " size: " + lastPlatformWidth);
    }

    private void Update()
    {
        platformGO.transform.Translate(platformManager.Speed * Time.deltaTime * Vector2.left);
        InactivatePlatform();
    }

    private void InactivatePlatform()
    {
        if ((platformGO.transform.position.x + lastPlatformWidth) < platformManager.EndingPointGO.transform.position.x)
        {
            platformGO.SetActive(false);
        }
    }

    private void CheckPlatformWidth()
    {
        BoxCollider2D boxCollider = platformGO.GetComponent<BoxCollider2D>();
        lastPlatformWidth = boxCollider.bounds.size.x;
    }
}
