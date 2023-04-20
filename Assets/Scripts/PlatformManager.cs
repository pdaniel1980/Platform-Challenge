using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] GameObject lastPlatformGO;
    [SerializeField] GameObject startingPointGO;
    [SerializeField] GameObject[] prefabPlatforms;
    [SerializeField] float speed;
    
    int platformNumber = 0;
    float lastPlatformWidth;
    float spaceBetweenPlatforms;

    public float Speed { get => speed; }

    private void Start()
    {
        SelectPlatform();
    }

    private void Update()
    {
        if (lastPlatformGO.transform.position.x < startingPointGO.transform.position.x)
        {
            SelectPlatform();
        }
    }

    private void SelectPlatform()
    {
        int index = Random.Range(0, prefabPlatforms.Length);
        spaceBetweenPlatforms = Random.Range(1.5f, 5f);
        Vector3 targetCreationPoint = new Vector3(startingPointGO.transform.position.x + lastPlatformWidth + spaceBetweenPlatforms, startingPointGO.transform.position.y, 0);
        lastPlatformGO = Instantiate(prefabPlatforms[index], targetCreationPoint, Quaternion.identity);
        lastPlatformGO.name = "Platform_" + platformNumber;
        platformNumber++;
        CheckPlatformWidth();
    }

    private void CheckPlatformWidth()
    {
        BoxCollider2D boxCollider = lastPlatformGO.GetComponent<BoxCollider2D>();
        lastPlatformWidth = boxCollider.bounds.size.x;
    }

    public void Stop()
    {
        speed = 0;
    }
}
