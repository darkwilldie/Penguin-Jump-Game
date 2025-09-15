using UnityEngine;
using UnityEngine.UI; // If using legacy UI
// using TMPro; // If using TextMeshPro

public class PenguinPlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private Vector3 originalScale;
    private bool facingRight = true;

    public GameObject gameOverText; // Assign in Inspector

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        originalScale = transform.localScale;
    }

    void Update()
    {
        // Only allow left/right movement
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Flip player sprite based on movement direction
        if (moveInput < 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        }
        else if (moveInput > 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        }

        // Jump if grounded and jump key pressed
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void FixedUpdate()
    {
        // You can add physics-related code here if needed
    }

    // Simple ground check using collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts.Length > 0)
        {
            // Check if collision is from below
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (contact.normal.y > 0.5f)
                {
                    isGrounded = true;
                    break;
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("River")) // Tag your river GameObject as "River"
        {
            if (gameOverText != null)
            {
                gameOverText.SetActive(true);
            }
            // Optionally, disable player movement here
        }
    }
}
