
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float jumpForce = 12f;
    public LayerMask groundLayer;
    public Transform groundCheck;

    private Rigidbody2D rb;
    private bool isGrounded;
    private float horizontalInput;
    private Animator anim;
  
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // 1. Get Input
        horizontalInput = Input.GetAxisRaw("Horizontal");

        // 2. Ground Check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        // 3. Jump (Only change Y, leave X alone)
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // 4. Flip Logic (Now with a safety check)
        FlipCharacter();
        {
            // Use the absolute value of horizontal input (0 to 1) 
            // or your actual velocity to drive the animation
            float horizontalInput = Mathf.Abs(Input.GetAxisRaw("Horizontal"));

        // Update the 'Speed' parameter in the Animator
        anim.SetFloat("Speed", horizontalInput);
    }
}

    void FixedUpdate()
    {
        // 5. Movement (Use linearVelocityX to avoid 'stomping' the jump)
        rb.linearVelocityX = horizontalInput * moveSpeed;
    }

    void FlipCharacter()
    {
        // Use '1' or '-1' instead of the raw input value to prevent shrinking
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(3.611436f, 3.611436f, 3.611436f);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-3.611436f, 3.611436f, 3.611436f);
    }

}