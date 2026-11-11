using UnityEngine;

public class SoundTrap : MonoBehaviour
{

    private GameObject player;

    public GameObject SoundSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        player = GameObject.FindWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {

            Debug.Log("Player entered sound trap");
            Instantiate(SoundSource, transform.position, transform.rotation);

        }
    }

}
