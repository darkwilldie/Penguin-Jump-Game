using UnityEngine;
using UnityEngine.UI; // If using legacy UI
// using TMPro; // If using TextMeshPro
using UnityEngine.SceneManagement;

public class PenguinPlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool gameOver = false;
    private bool isGrounded;
    public Transform groundCheck; // Assign in Inspector, place at player's feet
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer; // Assign in Inspector to your ground layer
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
        if (gameOver) return;

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
        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W)) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void FixedUpdate()
    {
        // Reliable ground check using OverlapCircle
        if (groundCheck != null)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        }
    }

    // Remove old collision-based ground check

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Deadly")) // Tag your deadly GameObject as "Deadly"
        {
            gameOver = true;
            rb.velocity = Vector2.zero;
            if (gameOverText != null)
                gameOverText.SetActive(true);
        }
    }

    // Call this from your UI Button's OnClick event
    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
