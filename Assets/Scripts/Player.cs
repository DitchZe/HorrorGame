using UnityEngine;

public class Player : MonoBehaviour
{

    float speed = 5f;

    Vector2 movementInput;
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        movementInput.x = Input.GetAxis("Horizontal");
        movementInput.y = Input.GetAxis("Vertical");

        rb.linearVelocity = movementInput.normalized * speed;

    }
}
