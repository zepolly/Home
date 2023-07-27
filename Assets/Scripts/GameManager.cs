using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class GameManager : MonoBehaviour
{
    public GameObject startScreen;
    public GameObject gameOverText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI countText;
    public bool isGameActive;
    public bool gameOver;
    public int countBorder = 200;
    public bool complited;

    private int score;
    private int count;
   
    public void UpdateScore(int scoreAdd)
    {
        score += scoreAdd;
        scoreText.text = "Firefly: " + score;
        count = countBorder - score;
        countText.text = "You need: " + count;

        if (count == 0 || count < 0)
        {
            countText.text = "You need go to home";
            complited = true;
        }
    }

    public void Restart()
    {
        gameOverText.SetActive(false);
        StartGame();
    }

    public void StartGame()
    {
        complited = false;
        gameOver = false;
        isGameActive = true;
        startScreen.SetActive(false);
        scoreText.gameObject.SetActive(true);
        score = 0;
        UpdateScore(0);
    }
}
