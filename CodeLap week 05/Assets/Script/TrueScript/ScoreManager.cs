using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ScoreManager : MonoBehaviour
{
    //set this to be static
    public static ScoreManager scoreManager;
    
    //initiate the class
    public Player_Score[] playerScore;

    void Awake()
    {
        if (scoreManager == null)
        {
            DontDestroyOnLoad(gameObject);
            scoreManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StoreScore() //use this to score current score in storedScore
    {
        for (int i = 0; i < playerScore.Length; i++)
        {
            playerScore[i].storedScore = playerScore[i].currentScore;
        }
        ScoreUI.systemScore.ShowScore();
    }

    public void ResetScore() //use this to reset the score to 0
    {
        for (int i = 0; i < playerScore.Length; i++)
        {
            playerScore[i].currentScore = 0;
        }
        ScoreUI.systemScore.ShowScore();
    }

    public void RowbackScore() //use this to reset currentScore  to storedScore
    {
        for (int i = 0; i < playerScore.Length; i++)
        {
            playerScore[i].currentScore = playerScore[i].storedScore;
        }
        ScoreUI.systemScore.ShowScore();
    }

    public void resetStoredScored() //use this to reset storedScore to 0
    {
        for (int i = 0; i < playerScore.Length; i++)
        {
            playerScore[i].storedScore = 0;
        }

        ScoreUI.systemScore.ShowScore();
    }
}

[System.Serializable]
//set up score for each player
public class Player_Score
{
    public string name;
    public int currentScore;
    public int storedScore;
}