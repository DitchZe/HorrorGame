using UnityEngine;

public class SoundSource : MonoBehaviour
{
    //for now decibels = distance
    public float decibels;

    private GameObject monster;
    public Transform monsterD;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() 
    {

        monster = GameObject.FindWithTag("Monster");
        monsterD = monster.transform;


    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector2.Distance(transform.position, monsterD.position);

        if (distance <= decibels) 
        {

            

        }

    }
}
