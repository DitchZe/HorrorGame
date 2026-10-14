using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public TMP_Text coinText;
    private int coinCount = 0;

    public void AddCoin() 
    {

        coinCount++;
        coinText.text = "Coins: " + coinCount.ToString();
    
    }

}
