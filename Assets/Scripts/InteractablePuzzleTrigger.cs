using UnityEngine;

public class InteractablePuzzleTrigger : MonoBehaviour
{
    [Header("Assign the Puzzle Screen")]
    public GameObject puzzleCanvas; 

    // CHANGE THIS: Replace 'PlayerMovement' with your actual player movement script name!
    private MonoBehaviour playerMovementScript; 
    private bool isPuzzleActive = false;

    void Start()
    {
        // Automatically find the player's movement script in the scene
        // (Assuming your player object has a script like PlayerMovement, CharacterController2D, etc.)
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            // Update this string to match your exact player script class name
            playerMovementScript = player.GetComponent("PlayerMovement") as MonoBehaviour; 
        }
    }

    public void onInteraction()
    {
        if (puzzleCanvas == null) return;

        if (!isPuzzleActive) { OpenPuzzle(); }
        else { ClosePuzzle(); }
    }

    private void OpenPuzzle()
    {
        puzzleCanvas.SetActive(true);
        isPuzzleActive = true;

        // Freeze ONLY the player by turning off their control script
        if (playerMovementScript != null)
        {
            playerMovementScript.enabled = false; 
        }
        
        Debug.Log("Puzzle opened. Player controls frozen. Enemies are still active!");
    }

    public void ClosePuzzle()
    {
        puzzleCanvas.SetActive(false);
        isPuzzleActive = false;

        // Unfreeze the player by re-enabling their control script
        if (playerMovementScript != null)
        {
            playerMovementScript.enabled = true; 
        }
        
        Debug.Log("Puzzle closed. Player controls restored.");
    }

    void OnDisable()
    {
        if (isPuzzleActive) { ClosePuzzle(); }
    }
}