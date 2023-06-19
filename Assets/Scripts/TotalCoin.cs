using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TotalCoin : MonoBehaviour
{
    public TextMeshProUGUI totalcoinText;
    private int currentCoin;

    private void Awake()
    {
        currentCoin = PlayerPrefs.GetInt("CurrentCoin", 0);
        UpdateCoinText();
    }

    void UpdateCoinText()
    {
        totalcoinText.text = currentCoin.ToString();
    }
}
