using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5f;
    private float jumpForce = 3f;
    private Rigidbody2D rb;

    [SerializeField] private float groundCheckRadius = 0.1f;
    private Transform groundCheck;
    private LayerMask groundLayer;
    private bool isGrounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        groundCheck = transform.Find("GroundCheck");

        groundLayer = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        CheckGround();
        float movementHorizontal = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(movementHorizontal * speed, rb.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector2(
            rb.linearVelocity.x,
            jumpForce);
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );
    }

}
