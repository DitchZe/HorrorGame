using UnityEngine;

public class InteractionManager : MonoBehaviour
{

    public static InteractionManager Instance { get; private set; }
    
    public GameObject currentObject;

    void Awake() 
    {
    
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }

    }

    public void SetObject(GameObject obj) 
    {
    
        currentObject = obj;

    }

    public void ClearObject(GameObject obj) 
    {

        if (currentObject == obj) 
        {
        
            currentObject = null;

        }

    }

    void Update() 
    {

        if (Input.GetKeyDown(KeyCode.E) && currentObject != null) 
        {

            currentObject.SendMessage("onInteraction", SendMessageOptions.DontRequireReceiver);
        
        }
    
    }

}
