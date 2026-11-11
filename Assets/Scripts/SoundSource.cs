using UnityEngine;

public class SoundSource : MonoBehaviour
{
    //for now decibels = distance
    public float decibels;

    private GameObject monster;
    private Monster monsterScript;
    public Transform monsterD;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() 
    {

        monster = GameObject.FindWithTag("Monster");

        if (monster == null)
        {

            Debug.Log("Monster not found");
            Destroy(gameObject);

        }

        monsterScript = monster.GetComponent<Monster>();
        monsterD = monster.transform;

        

        SoundSource[] allInstances = Object.FindObjectsByType<SoundSource>();

        foreach (SoundSource instance in allInstances) 
        {

            if (instance.gameObject != this.gameObject) 
            {

                Destroy(instance.gameObject);
                break;
            
            }
        
        }


    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector2.Distance(transform.position, monsterD.position);

        if (distance <= decibels && monsterScript.currentState == state.Default)
        {

            monsterScript.currentState = state.SoundHeard;

        }
        else 
        {

            Destroy(gameObject);

        }

    }
}
