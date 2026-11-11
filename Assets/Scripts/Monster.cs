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

                

                if (charging)
                {

                    rb.linearVelocity = (targetP.position - transform.position).normalized * speed;

                }
                else 
                {
                
                    rb.linearVelocity = Vector2.zero;
                    currentState = state.Default;

                }

                charging = true;


                break;

        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("SoundSource")) 
        {

            Destroy(target);
            currentState = state.Default;

        }

        if (other.CompareTag("Wall") && currentState == state.Default)
        {

            //Vector2 wallNormal = other.contacts[0].normal

        }


    }

    private void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.CompareTag("Wall") && currentState == state.SoundHeard)
        {

            Debug.Log("Collide with wall");
            rb.linearVelocity = Vector2.zero;
            charging = false;
            currentState = state.Default;

        }

    }

}
