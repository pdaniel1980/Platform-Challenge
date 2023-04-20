using System.Collections;
using UnityEngine;

public class EnvironmentController : MonoBehaviour
{
    [SerializeField] GameObject[] environmentGO;
    [SerializeField] Transform startingPointTransform;
    [SerializeField] int waitForCreation;

    private void Start()
    {
        StartCoroutine(CreateEnvironmentElement());
    }

    IEnumerator CreateEnvironmentElement()
    {
        int elementIndex = Random.Range(0, environmentGO.Length);
        Instantiate(environmentGO[elementIndex],
            new Vector3(startingPointTransform.position.x, environmentGO[elementIndex].transform.position.y, 1)
            , Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(waitForCreation, waitForCreation * 2));
        StartCoroutine(CreateEnvironmentElement());
    }
}
