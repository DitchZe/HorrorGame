using UnityEngine;

public class Test : MonoBehaviour
{

    public Transform player;
    public int targetDistance = 1;

    private SpriteRenderer sr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        sr = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        //color change is for debugging and does not have to stay
        sr.color = Color.red;
        //this is
        InteractionManager.Instance.SetObject(gameObject);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        sr.color = Color.white;
        InteractionManager.Instance.ClearObject(gameObject);

    }

    void onInteraction() 
    {

        Debug.Log("Test");
    
    }

}
