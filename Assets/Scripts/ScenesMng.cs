using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesMng : MonoBehaviour
{
    //for scene manage
    
   public void OnTryAgainButtonClicked()
    {
        // Oyun sahnesini yeniden yükle
        Debug.Log("tıkladın");
        SceneManager.LoadScene("SampleScene");
        
    }

    public void OnPlayButtonClicked()
    {
        // Oyun sahnesini yeniden yükle
        Debug.Log("tıkladın");
        SceneManager.LoadScene("SampleScene");
    }
    public void OnMainMenuButtonClicked()
    {
        // Oyun sahnesini yeniden yükle
        Debug.Log("tıkladın");
        SceneManager.LoadScene("MainMenu");
    }
    public void OnStoreButtonClicked()
    {
        // Oyun sahnesini yeniden yükle
        Debug.Log("tıkladın");
        SceneManager.LoadScene("Store");
    }
}
