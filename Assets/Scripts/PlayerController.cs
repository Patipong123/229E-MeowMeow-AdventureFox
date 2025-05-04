using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int maxHearts = 3;
    private int currentHearts;

    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public Transform groundCheck;          
    public float checkRadius = 0.1f;
    public LayerMask groundLayer;

    public float fallThresholdY = -10f;

    private Rigidbody2D rb;
    private float moveInput;
    private bool isGrounded;

    public HeartUI heartUI;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

        currentHearts = maxHearts;
        if (heartUI != null)
        {
            heartUI.UpdateHearts(currentHearts); 
        }
    }

    void Update()
    {
        

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        moveInput = Input.GetAxisRaw("Horizontal");

        Vector3 scale = transform.localScale;
        if (moveInput > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        else if (moveInput < 0)
        {
            scale.x = -Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        bool isRunning = Mathf.Abs(moveInput) > 0.1f;
        animator.SetBool("isRunning", isRunning);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); 
        }

        if (transform.position.y < fallThresholdY && currentHearts > 0)
        {
            currentHearts = 0;
            TakeDamage(0); 
        }




    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            
            TakeDamage(1);
        }
    }

    void TakeDamage(int damage)
    {
        currentHearts -= damage;
        if (currentHearts < 0) currentHearts = 0;

        Debug.Log("Hearts left: " + currentHearts);

        if (heartUI != null)
            heartUI.UpdateHearts(currentHearts);

        if (currentHearts <= 0)
        {
            Debug.Log("Game Over!");
            
        }
    }
}
