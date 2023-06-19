using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Coin : MonoBehaviour
{

    // //This script manages the collection of coins and bonuses in the game. 
    // It keeps track of the player's current coin count and updates the displayed count on the screen. 
    // When the player collides with a coin or a bonus object, the corresponding object is deactivated, and the coin count is increased. 
    // The updated count is saved and displayed.
   public int currentCoin ;
   public TextMeshProUGUI coinText;
private void Awake()
    {
        
        currentCoin = PlayerPrefs.GetInt("CurrentCoin", 0);
        coinText.text =  currentCoin.ToString();
        
    }
   private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("coin"))
        {
    
            collision.gameObject.SetActive(false);
            Debug.Log("You get coin! +5 ");
            GetCoin(5);
           
        }
        else if (collision.gameObject.CompareTag("bonus"))
        {
    
            collision.gameObject.SetActive(false);
            Debug.Log("You get bonus! +10 ");
            GetCoin(10);
           
        }
    }
     void GetCoin(int amount)
    {
        currentCoin += amount; 
        Debug.Log( "You have "+ currentCoin +"coin");
        UpdateCoinText();

        PlayerPrefs.SetInt("CurrentCoin", currentCoin);

    
    }
     void UpdateCoinText()
    {
        
            coinText.text =  currentCoin.ToString();
        
    }
}
