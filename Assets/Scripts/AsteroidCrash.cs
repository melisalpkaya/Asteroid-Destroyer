using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

using UnityEngine.UI;
using TMPro;

public class AsteroidCrash : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{

    //This script manages the collision of the player with asteroids.
    // It tracks the player's health, disables asteroids upon collision, and checks for winning conditions. 
    // Additionally, it utilizes the Unity Ads API to load and display advertisements. 
    // The script implements callback functions related to ad loading and showing.

    public int maxHealth = 3; 
    public int asteroidNum = 8; 
    private int currentHealth; 
    public GameObject heart1; // heart objects
    public GameObject heart2;
    public GameObject heart3;


     [SerializeField] string _androidAdUnitId = "Interstitial_Android";
    [SerializeField] string _iOsAdUnitId = "Interstitial_iOS";
    string _adUnitId;
 
    void Awake()
    {
        // Get the Ad Unit ID for the current platform:
        _adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOsAdUnitId
            : _androidAdUnitId;
    }
    
    void Start()
    {
        currentHealth = maxHealth; // set the health to max health at the start
        heart1.SetActive(true);
        heart2.SetActive(true);
        heart3.SetActive(true);

        LoadAd();
       
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("asteroid"))
        {
            //Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
            TakeDamage(1);
            asteroidNum--;
            if (asteroidNum == 0)
            {
                Debug.Log(asteroidNum);
                SceneManager.LoadScene("YouWon");
            }
        }
    }
    void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // reduce health

        // Kalp objelerini kapat
        if (currentHealth == 2)
        {
            heart3.SetActive(false);
        }
        else if (currentHealth == 1)
        {
            heart2.SetActive(false);
        }
        else if (currentHealth <= 0)
        {
            heart1.SetActive(false);
            
          
            Debug.Log("Game Over!");
            ShowAd();
        }
    }
    
 
    // Load content to the Ad Unit:
    public void LoadAd()
    {
        
        Debug.Log("Loading Ad: " + _adUnitId);
        Advertisement.Load(_adUnitId, this);
    }
 
    // Show the loaded content in the Ad Unit:
    public void ShowAd()
    {
        
        Debug.Log("Showing Ad: " + _adUnitId);
        Advertisement.Show(_adUnitId, this);
    }
 
    // Implement Load Listener and Show Listener interface methods: 
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        
    }
 
    public void OnUnityAdsFailedToLoad(string _adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit: {_adUnitId} - {error.ToString()} - {message}");
        
    }
 
    public void OnUnityAdsShowFailure(string _adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {_adUnitId}: {error.ToString()} - {message}");
        
    }
 
    public void OnUnityAdsShowStart(string _adUnitId) { 

    }
    public void OnUnityAdsShowClick(string _adUnitId) {
        
     }
    public void OnUnityAdsShowComplete(string _adUnitId, UnityAdsShowCompletionState showCompletionState) {  
         if (showCompletionState == UnityAdsShowCompletionState.COMPLETED)
    {
        
        Debug.Log("Ad completed, add 1 life and continue the game");
        currentHealth++;
        heart1.SetActive(true);
    }
    else if(showCompletionState == UnityAdsShowCompletionState.SKIPPED){
        Debug.Log("Ad skipped");
        currentHealth = 0;
        SceneManager.LoadScene("GameOver");

    }

    }

       

}
