using UnityEngine;

public class BackdropController : MonoBehaviour
{

    SpriteRenderer spriteRenderer;
    [SerializeField] float speed = 1f;
    float offset = 0;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        offset += Time.deltaTime * speed;
        spriteRenderer.material.mainTextureOffset = new Vector2(offset, 0);
    }

}
