using UnityEngine;
using UnityEngine.UI; // Use UnityEngine.UIElements if using modern UI Toolkit

public class CyclePuzzleController : MonoBehaviour
{
    [Header("Puzzle Settings")]
    public int totalLights = 5;
    
    [Header("Visual Components")]
    public Image[] lightImages; // Assign your 5 Button Images here in order (0 to 4)
    public Color colorOn = Color.yellow;
    public Color colorOff = Color.gray;

    // Track the true boolean state of each light
    private bool[] lightStates;

    void Start()
    {
        lightStates = new bool[totalLights];
        RandomizePuzzle();
    }

    // Call this function when a user clicks a button. Pass the button's index (0-4).
    public void OnLightClicked(int index)
    {
        // 1. Toggle the clicked light
        ToggleLight(index);

        // 2. Toggle Left Neighbor (with modulo wrap-around)
        int leftNeighbor = (index - 1 + totalLights) % totalLights;
        ToggleLight(leftNeighbor);

        // 3. Toggle Right Neighbor (with modulo wrap-around)
        int rightNeighbor = (index + 1) % totalLights;
        ToggleLight(rightNeighbor);

        // Update visuals and check for win condition
        UpdateVisuals();
        CheckWinCondition();
    }

    private void ToggleLight(int index)
    {
        lightStates[index] = !lightStates[index];
    }

    private void UpdateVisuals()
    {
        for (int i = 0; i < totalLights; i++)
        {
            lightImages[i].color = lightStates[i] ? colorOn : colorOff;
        }
    }

    private void RandomizePuzzle()
    {
        // Don't just randomize bools freely, or the puzzle might be mathematically impossible!
        // Instead, simulate random "clicks" to ensure it's always solvable.
        for (int i = 0; i < 5; i++)
        {
            if (Random.value > 0.5f)
            {
                OnLightClicked(Random.Range(0, totalLights));
            }
        }
        
        // Ensure we didn't accidentally solve it instantly during setup
        if (IsPuzzleSolved()) 
        {
            RandomizePuzzle();
        }
    }

    private bool IsPuzzleSolved()
    {
        foreach (bool state in lightStates)
        {
            if (!state) return false; // If any light is false (off), puzzle isn't solved
        }
        return true;
    }

    private void CheckWinCondition()
    {
        if (IsPuzzleSolved())
        {
            Debug.Log("Puzzle Solved! Unlock the door.");
            // Add your win logic here (e.g., fire an event, play a sound, load a scene)
        }
    }
}
