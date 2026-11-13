using UnityEngine;
using UnityEngine.AI;

public enum state 
{

    Default,
    SoundHeard

}

public class Monster : MonoBehaviour
{

    public state currentState;

    private Rigidbody2D rb;

    public GameObject target;
    private Transform targetP;

    public float speed = 5f;
    public float wanderSpeed = 2f;
    private bool charging = false;
    private Vector2 randomDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        currentState = state.Default;
        rb = GetComponent<Rigidbody2D>();

        float angle = Random.Range(0f, Mathf.PI * 2f);
        randomDirection = new Vector2(Mathf.Cos(angle),Mathf.Sin(angle));

    }

    // Update is called once per frame
    void Update()
    {

        switch (currentState) 
        {

            case state.Default:

                rb.linearVelocity = randomDirection * wanderSpeed;

                break;

            case state.SoundHeard:

                target = GameObject.FindWithTag("SoundSource");
                targetP = target.transform;


                rb.linearVelocity = (targetP.position - transform.position).normalized * speed;



                break;

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("SoundSource")) 
        {

            Destroy(target);
            currentState = state.Default;

        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(currentState == state.Default)
        {
            Vector2 wallNormal = collision.contacts[0].normal;

            randomDirection = Vector2.Reflect(randomDirection, wallNormal).normalized;
        }

        if (currentState == state.SoundHeard)
        {

            Vector2 wallNormal = collision.contacts[0].normal;

            randomDirection = Vector2.Reflect(randomDirection, wallNormal).normalized;
            currentState = state.Default;

        }

    }

}
