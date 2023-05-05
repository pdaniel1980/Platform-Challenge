using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject audioFXGO;
    AudioFX audioFX;
    [SerializeField] GameObject playerGO;
    [SerializeField] float jumpForce;
    [SerializeField] Transform transformCheckGroundedPoint;
    [SerializeField] GameObject scoreManagerGO;
    ScoreManager scoreManager;
    Rigidbody2D rb;
    
    Animator animatorPlayer;
    int jumpId;
    int landingId;
    bool isGrounded;
    [SerializeField] float groundedDistance;
    [SerializeField] LayerMask layerMask;
    float lastPlayerPositionY;

    bool canDoubleJump;
    bool isDoubleJumpEnable;
    bool hitGround;

    private void Awake()
    {
        jumpId = Animator.StringToHash("Jump");
        landingId = Animator.StringToHash("IsLanding");
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        lastPlayerPositionY = transformCheckGroundedPoint.position.y;
        animatorPlayer = playerGO.GetComponent<Animator>();
        audioFX = audioFXGO.GetComponent<AudioFX>();
        scoreManager = scoreManagerGO.GetComponent<ScoreManager>();
    }

    void Update()
    {
        CheckJump();
        CheckIsGrounded();
        CheckIsLanding();
    }

    void CheckJump()
    {
        bool jumpKeyPressed = Input.GetKeyDown(KeyCode.Space);

        if ((isGrounded || (canDoubleJump && isDoubleJumpEnable)) && jumpKeyPressed)
        {
            if (isGrounded && isDoubleJumpEnable)
                canDoubleJump = true;
            else
                canDoubleJump = false;

            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animatorPlayer.SetTrigger(jumpId);
            audioFX.PlayFX(AudioFX.AudioClipName.Jump);
        }
    }

    void CheckIsLanding()
    {
        if (lastPlayerPositionY >= transformCheckGroundedPoint.position.y)
        {
            animatorPlayer.SetBool(landingId, true);
        }

        if (isGrounded)
        {
            animatorPlayer.SetBool(landingId, false);
        }

        lastPlayerPositionY = transformCheckGroundedPoint.position.y;
    }

    void CheckIsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(transformCheckGroundedPoint.position, Vector2.down, groundedDistance, layerMask);

        isGrounded = raycastHit2D;

        if (hitGround)
        {
            audioFX.PlayFX(AudioFX.AudioClipName.Land);
            hitGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (isGrounded && other.gameObject.CompareTag("Ground"))
        {
            hitGround = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Coin":
                audioFX.PlayFX(AudioFX.AudioClipName.Coin);
                scoreManager.CoinsCollected += 1;
                //Destroy(collision.gameObject);
                collision.gameObject.SetActive(false);
                break;
            case "DoubleJump":
                audioFX.PlayFX(AudioFX.AudioClipName.DoubleJump);
                //Destroy(collision.gameObject);
                collision.gameObject.SetActive(false);
                isDoubleJumpEnable = true;
                break;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transformCheckGroundedPoint.position, groundedDistance);
    }
}
