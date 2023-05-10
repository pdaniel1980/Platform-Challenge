using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject playerGO;
    [SerializeField] float limit = -5f;
    Transform playerTransform;
    Transform cameraTransform;

    private void Awake()
    {
        cameraTransform = transform;
    }

    private void Start()
    {
        playerTransform = playerGO.transform;
    }

    void Update()
    {
        if (cameraTransform.position.y > limit)
        {
            cameraTransform.position = new Vector3(cameraTransform.position.x, playerTransform.position.y, cameraTransform.position.z);
        }
    }
}
