using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using TMPro;
using UnityEngine.UI;
public class IAPManager : MonoBehaviour
{

    //this script handles in-app purchases, updates ship button texts, deducts coin amounts, and stores the purchased status and ship selection in PlayerPrefs.
    [SerializeField]  TextMeshProUGUI totalcoinText;
    public ShipButton shipButton1;
    public ShipButton shipButton2;
    public ShipButton shipButton3;

    

    private int currentCoin;

    private void Awake()
    {
        currentCoin = PlayerPrefs.GetInt("CurrentCoin", 0);
        LoadPurchasedStatus();
    }

    private void Start()
    {
        shipButton1.InitializeButton(this, "com.melisalpkaya.blueShip");
        shipButton2.InitializeButton(this, "com.melisalpkaya.redShip");
        shipButton3.InitializeButton(this, "com.melisalpkaya.greenShip");

        UpdateButtonTexts();
    }

    public void onPurchaseComplete(Product product)
    {
        decimal price = product.metadata.localizedPrice;

        if (product.definition.id == shipButton1.productId)
        {
            Debug.Log("Mavi gemi başarıyla satın alındı.");
            shipButton1.UpdateButtonText();
            if (currentCoin >= price)
            {
                DecreaseCoin(price);
                SetItemPurchased(shipButton1.productId);
            }
        }
        else if (product.definition.id == shipButton2.productId)
        {
            Debug.Log("Kırmızı gemi başarıyla satın alındı.");
            shipButton2.UpdateButtonText();
            if (currentCoin >= price)
            {
                DecreaseCoin(price);
                SetItemPurchased(shipButton2.productId);
                
            }
        }
        else if (product.definition.id == shipButton3.productId)
        {
            Debug.Log("Yeşil gemi başarıyla satın alındı.");
            shipButton3.UpdateButtonText();
            if (currentCoin >= price)
            {
                DecreaseCoin(price);
                SetItemPurchased(shipButton3.productId);
            }
        }
    }

    public void onPurchaseFailed(Product product, PurchaseFailureReason reason)
    {
        Debug.Log("Ürün adı: " + product.definition.id + reason + "sebebinden dolayı alınamadı.");
    }

    public void DecreaseCoin(decimal price)
    {
        currentCoin -= Mathf.RoundToInt((float)price);
        totalcoinText.text = currentCoin.ToString();
        PlayerPrefs.SetInt("CurrentCoin", currentCoin);
        PlayerPrefs.Save();
    }

    private void SetItemPurchased(string productId)
    {
        PlayerPrefs.SetInt(GetPurchasedKey(productId), 1);
        PlayerPrefs.Save();
    }

    private bool IsItemPurchased(string productId)
    {
        return PlayerPrefs.GetInt(GetPurchasedKey(productId), 0) == 1;
    }

    private void LoadPurchasedStatus()
    {
        if (IsItemPurchased(shipButton1.productId))
            shipButton1.UpdateButtonText();
        if (IsItemPurchased(shipButton2.productId))
            shipButton2.UpdateButtonText();
        if (IsItemPurchased(shipButton3.productId))
            shipButton3.UpdateButtonText();
    }

    private void UpdateButtonTexts()
    {
        if (IsItemPurchased(shipButton1.productId))
            shipButton1.UpdateButtonText();
        if (IsItemPurchased(shipButton2.productId))
            shipButton2.UpdateButtonText();
        if (IsItemPurchased(shipButton3.productId))
            shipButton3.UpdateButtonText();
    }

    private string GetPurchasedKey(string productId)
    {
        return "Purchased_" + productId;
    }

    public void Choose1()
    {
       bool choose = true;
       Debug.Log(choose);
       PlayerPrefs.SetInt("ChooseValue", choose ? 1 : 0);
       PlayerPrefs.Save();
    }
    public void Choose2()
    {
       bool choose = false;
       Debug.Log(choose);
       PlayerPrefs.SetInt("ChooseValue", choose ? 1 : 0);
       PlayerPrefs.Save();
    }
}

[System.Serializable]
public class ShipButton
{
    public Button button;
    public TextMeshProUGUI buttonText;
    public string productId;

    private IAPManager iapManager;

    public void InitializeButton(IAPManager manager, string id)
    {
        iapManager = manager;
        productId = id;
    }

    public void UpdateButtonText()
    {
        buttonText.text = "Purchased";
    }
}
