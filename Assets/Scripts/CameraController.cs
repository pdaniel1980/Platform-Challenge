using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject playerGO;
    [SerializeField] float limit = -5f;

    void Update()
    {
        if (transform.position.y > limit)
        {
            transform.position = new Vector3(transform.position.x, playerGO.transform.position.y, transform.position.z);
        }
    }
}
