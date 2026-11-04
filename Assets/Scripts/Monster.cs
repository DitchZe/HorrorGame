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

    private NavMeshAgent agent;
    
    public GameObject target;
    private Transform targetP;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        currentState = state.Default;
        //agent = GetComponent<NavMeshAgent>();

        target = GameObject.FindWithTag("SoundSource");
        targetP = target.transform;

    }

    // Update is called once per frame
    void Update()
    {

        switch (currentState) 
        {

            case state.Default:



                break;

            case state.SoundHeard:

                target = GameObject.FindWithTag("SoundSource");
                targetP = target.transform;

                if (target != null)
                {

                    transform.position = Vector3.MoveTowards(transform.position, targetP.position, 0.01f);

                }
                else 
                {

                    currentState = state.Default;

                }




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

        Debug.Log("Collide");

    }

}
