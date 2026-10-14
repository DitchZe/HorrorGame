using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float pSpeed = 5f;
    private float moveX = 0;
    private float jumpForce = 5f;
    private int maxJump = 2;
    private float startX = 0;
    private float startY = 0;
    private float startZ = 0;
    
    void Start()
    {

        this.rb = GetComponent<Rigidbody2D>();

        startX = transform.position.x;
        startY = transform.position.y;
        startZ = transform.position.z;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.D)) { moveX = 1f; }
        else if (Input.GetKey(KeyCode.A)) { moveX = -1f; }
        else { moveX = 0; }

        rb.linearVelocity = new Vector2(moveX * pSpeed, rb.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.W) && maxJump != 0) 
        {

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            maxJump--;
        
        }

    }

    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Collectable")) 
        {

            Destroy(collision.gameObject);
            FindAnyObjectByType<ScoreManager>(FindObjectsInactive.Include).AddCoin();

        
        }

        if (collision.gameObject.CompareTag("Trap")) 
        {

            transform.position = new Vector3(startX, startY, startZ);

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ground")) 
        {

            maxJump = 2;

        }

    }

}
