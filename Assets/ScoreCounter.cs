using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class ScoreCounter : MonoBehaviour
{

    public int scorePerWall;

    public int scoreRed;
    public int scoreBlue;

    public TMP_Text blueText;
    public TMP_Text redText;

    public int cubeCount;

    public static ScoreCounter instance;

    public Image winImage;


    public bool isPlaying = false;


    void Start()
    {
        instance = this;
    }

    public void WallCollided(string wallName)
    {
        if (wallName == "Red")
        {
            scoreRed += scorePerWall;
        }
        else if (wallName == "Blue")
        {
            scoreBlue += scorePerWall;
        }
        UpdateUI();

        cubeCount--;

        CheckWinConditions();
    }


    public void UpdateUI()
    {
        blueText.text = scoreBlue.ToString();
        redText.text = scoreRed.ToString();
    }
    

    public void CheckWinConditions()
    {
        if (cubeCount <= 0)
        {
            winImage.gameObject.SetActive(true);
            isPlaying = false;
        }
    }
    
}
