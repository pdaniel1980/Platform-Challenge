using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject audioFXGO;
    AudioFX audioFX;
    [SerializeField] GameObject playerGO;
    [SerializeField] float jumpForce;
    [SerializeField] Transform transformCheckGroundedPoint;
    [SerializeField] GameObject scoreManagerGO;
    private PlayerExtras playerExtras;
    Rigidbody2D rb;
    
    Animator animatorPlayer;
    int jumpId;
    int landingId;
    bool isGrounded;
    [SerializeField] float groundedDistance;
    [SerializeField] LayerMask layerMask;
    float lastPlayerPositionY;

    bool canDoubleJump;
    bool hitGround;

    private void Awake()
    {
        jumpId = Animator.StringToHash("Jump");
        landingId = Animator.StringToHash("IsLanding");
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerExtras = GetComponent<PlayerExtras>();
    }

    void Start()
    {
        lastPlayerPositionY = transformCheckGroundedPoint.position.y;
        animatorPlayer = playerGO.GetComponent<Animator>();
        audioFX = audioFXGO.GetComponent<AudioFX>();
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

        if ((isGrounded || (canDoubleJump && playerExtras.IsDoubleJumpEnable)) && jumpKeyPressed)
        {
            if (isGrounded && playerExtras.IsDoubleJumpEnable)
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

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transformCheckGroundedPoint.position, groundedDistance);
    }
}
