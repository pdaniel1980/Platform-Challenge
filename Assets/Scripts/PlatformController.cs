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
            ActivateChildrens(platformGO.transform);
        }
    }

    private void ActivateChildrens(Transform parentT)
    {
        for (int i = 0; i < parentT.childCount; i++)
        {
            parentT.GetChild(i).gameObject.SetActive(true);
        }
    }

    private void CheckPlatformWidth()
    {
        BoxCollider2D boxCollider = platformGO.GetComponent<BoxCollider2D>();
        lastPlatformWidth = boxCollider.bounds.size.x;
    }
}
