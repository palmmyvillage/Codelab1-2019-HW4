using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class ScoreManager : MonoBehaviour
{
    //set this to be static
    public static ScoreManager scoreManager;
    
    //initiate the class
    public Player_Score[] playerScore;
    
    //ini Highscore and record
    private const string GAME_RECORD = "/myGameRecord.txt";
    public int P1_winNumber;
    public int P2_winNumber;
    public int drawNumber;
    public string highScoreWinner_record;
    private string highScoreWinner_Local;
    public int highScore_record;
    private int highScore_Local;
    
    
    
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

        string recordFile = Application.dataPath + GAME_RECORD;

        if (!File.Exists(recordFile))
        {
            string output = "0";
            
            File.WriteAllText(recordFile,output);
        }
        else
        {
            //ini everything from saved record
            string RecordFileText = File.ReadAllText(recordFile);

            string[] recordSplit =RecordFileText.Split(' ');
            P1_winNumber = Int32.Parse(recordSplit[1]);
            P2_winNumber = Int32.Parse(recordSplit[3]);
            drawNumber = Int32.Parse(recordSplit[5]);
            highScore_record = Int32.Parse(recordSplit[7]);
            highScoreWinner_record = recordSplit[9];   
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

    public void setHighScore()
    {
        int P1score = playerScore[0].currentScore;
        int P2score = playerScore[1].currentScore;
        
        if (P1score > P2score)
        {
            highScore_Local = P1score;
            highScoreWinner_Local = "Player 1";
            P1_winNumber++;
        }
        else if (P2score >P1score)
        {
            highScore_Local = P2score;
            highScoreWinner_Local = "Player 2";
            P2_winNumber++;
        }
        else if (P1score == P2score)
        {
            highScore_Local = P1score;
            highScoreWinner_Local = "Draw";
            drawNumber++;
        }
        
        updateRecord();
    }

    public void updateRecord()
    {
        if (highScore_Local > highScore_record)
        {
            highScore_record = highScore_Local;
            highScoreWinner_record = highScoreWinner_Local;
        }

        string fullPathToRecord = Application.dataPath + GAME_RECORD;

        File.WriteAllText(fullPathToRecord, 
            "P1 " + P1_winNumber
            + " P2 " + P2_winNumber
            + " Draw " + drawNumber
            + " HighScore " + highScore_record
            + " HighScoreWinner " + highScoreWinner_record);
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