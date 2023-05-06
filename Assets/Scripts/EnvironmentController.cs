using System.Collections;
using UnityEngine;

public class EnvironmentController : MonoBehaviour
{
    [SerializeField] GameObject[] environmentGO;
    [SerializeField] Transform startingPointTransform;
    [SerializeField] int waitForCreation;

    private void Start()
    {
        DeactivateEnviroments();
        StartCoroutine(CreateEnvironmentElement());
    }

    private void DeactivateEnviroments()
    {
        for (int i = 0; i < environmentGO.Length; i++)
        {
            environmentGO[i] = Instantiate(environmentGO[i]);
            environmentGO[i].SetActive(false);
        }
    }

    IEnumerator CreateEnvironmentElement()
    {
        int elementIndex = Random.Range(0, environmentGO.Length);

        if (!environmentGO[elementIndex].activeSelf)
        {
            Vector3 targetPosition = new Vector3(startingPointTransform.position.x, environmentGO[elementIndex].transform.position.y, 1);
            environmentGO[elementIndex].SetActive(true);
            environmentGO[elementIndex].transform.position = targetPosition;
            yield return new WaitForSeconds(Random.Range(waitForCreation, waitForCreation * 2));
            StartCoroutine(CreateEnvironmentElement());
        }        
    }
}
