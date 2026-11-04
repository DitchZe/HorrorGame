using UnityEngine;

public enum state 
{

    Default,
    SoundHeard

}

public class Monster : MonoBehaviour
{

    public state currentState;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        currentState = state.Default;

    }

    // Update is called once per frame
    void Update()
    {

        switch (currentState) 
        {

            case state.Default:



                break;

            case state.SoundHeard:



                break;

        }

    }
}
