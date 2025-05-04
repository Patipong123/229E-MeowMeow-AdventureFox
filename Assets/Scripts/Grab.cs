using UnityEngine;

public class Grab : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isNearGrabbable = false;
    private Transform grabTarget = null;
    private bool isGrabbing = false;

    public KeyCode grabKey = KeyCode.E;

    private Vector3 grabOffset;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        
        if (Input.GetKeyDown(grabKey) && isNearGrabbable)
        {
            isGrabbing = !isGrabbing;

            if (isGrabbing)
            {
                
                rb.linearVelocity = Vector2.zero;

                rb.gravityScale = 0f;
                rb.bodyType = RigidbodyType2D.Kinematic; 
                rb.constraints = RigidbodyConstraints2D.None;

                if (grabTarget != null)
                {
                    transform.SetParent(grabTarget); 
                    transform.localPosition = Vector3.zero; 
                }
            }
            else
            {
                transform.SetParent(null); 
                rb.bodyType = RigidbodyType2D.Dynamic;    
                rb.gravityScale = 1f;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;

                transform.rotation = Quaternion.identity; 
            }
        }

        
        if (isGrabbing && Input.GetKeyDown(KeyCode.Space))
        {
            isGrabbing = false;

            transform.SetParent(null); 
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = 1f;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;

            transform.rotation = Quaternion.identity; 

            Vector2 jumpAwayForce = new Vector2(1f, 1.5f).normalized * 7f;
            rb.linearVelocity = jumpAwayForce;


        }

        
        if (isGrabbing && grabTarget != null)
        {
            transform.position = grabTarget.position + grabOffset;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Grab"))
        {
            isNearGrabbable = true;
            grabTarget = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Grab"))
        {
            isNearGrabbable = false;
            grabTarget = null;

        }
    }
}
