using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //this code was left unattended
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MenuReturn() 
    {

        SceneManager.LoadScene("Menu");

    }
}
