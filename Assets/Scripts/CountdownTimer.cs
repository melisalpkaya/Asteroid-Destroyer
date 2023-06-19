using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{

    //For 30 seconds of countdown timer.
    public TextMeshProUGUI countdownText;
    private float gameTime = 30f;
    private bool isGameOver = false;

    private void Start()
    {
        UpdateCountdownText();
    }

    private void Update()
    {
        if (!isGameOver)
        {
            if (gameTime > 0f)
            {
                gameTime -= Time.deltaTime;

                if (gameTime <= 0f)
                {
                    gameTime = 0f;
                    isGameOver = true;
                    EndGame();
                }

                UpdateCountdownText();
            }
        }
    }

    private void UpdateCountdownText()
    {
        countdownText.text = Mathf.CeilToInt(gameTime).ToString();
    }

    private void EndGame()
    {
        if (isGameOver)
        {
            //winning status
            bool hasWon = true; 

            if (hasWon)
            {
                SceneManager.LoadScene("YouWon");
            }
            else
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}
