using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 5f;
    public float defSpeed = 0;
    public bool sneaking = false;

    Vector2 movementInput;
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        defSpeed = speed;

    }

    // Update is called once per frame
    void Update()
    {

        movementInput.x = -Input.GetAxis("Horizontal");
        movementInput.y = Input.GetAxis("Vertical");

        rb.linearVelocity = movementInput.normalized * speed;


        if (Input.GetKey(KeyCode.LeftControl))
        {

            sneaking = true;
            speed = defSpeed / 2;

        }
        else 
        {

            speed = defSpeed;
            sneaking = false;

        }

    }
}
