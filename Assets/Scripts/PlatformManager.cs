using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] GameObject lastPlatformGO;
    [SerializeField] GameObject startingPointGO;
    [SerializeField] GameObject endingPointGO;
    [SerializeField] GameObject[] prefabPlatforms;
    [SerializeField] float speed;
    
    int platformNumber = 0;
    float lastPlatformWidth;
    float spaceBetweenPlatforms;
    
    float lastPlatformXReference;

    public float Speed { get => speed; }
    public GameObject EndingPointGO { get => endingPointGO; }

    private void Start()
    {
        InstantiatePlatforms();
        SelectPlatform();
    }

    private void Update()
    {
        lastPlatformXReference = lastPlatformGO.transform.position.x + lastPlatformWidth;
        if (lastPlatformXReference < startingPointGO.transform.position.x)
        {
            SelectPlatform();
        }
    }

    private void InstantiatePlatforms()
    {
        for (int i = 0; i < prefabPlatforms.Length; i++)
        {
            //go = Instantiate(prefabPlatforms[i], startingPointGO.transform.position, Quaternion.identity);
            //go.SetActive(false);
            //platforms.Add(go);
            //Vector3 targetOffsetPoint = new Vector3(startingPointGO.transform.position.x + spaceBetweenPlatforms, startingPointGO.transform.position.y, 0);
            
            prefabPlatforms[i] = Instantiate(prefabPlatforms[i]);
            prefabPlatforms[i].SetActive(false);
        }
    }

    private void SelectPlatform()
    {
        int index = Random.Range(0, prefabPlatforms.Length);

        if (prefabPlatforms[index].activeSelf)
            return;

        spaceBetweenPlatforms = Random.Range(1.5f, 5f);
        Vector3 targetOffsetPoint = new Vector3(startingPointGO.transform.position.x + spaceBetweenPlatforms, startingPointGO.transform.position.y, 0);
        //lastPlatformGO = Instantiate(prefabPlatforms[index], targetCreationPoint, Quaternion.identity);
        lastPlatformGO = prefabPlatforms[index];
        lastPlatformGO.SetActive(true);
        lastPlatformGO.transform.position = targetOffsetPoint;        
        lastPlatformGO.name = "Platform_" + platformNumber;
        platformNumber++;
        CheckPlatformWidth();
    }

    //private void SpaceBetweenPlatformsSpawned()
    //{
    //    spaceBetweenPlatforms = Random.Range(1.5f, 5f);
    //}

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
