using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    //set 
    public static ScoreUI systemScore;
    
    //set variable to store Player's ScoreText
    public Text Player1Point;
    public Text Player2Point;
    
    // Awake is called right away when the scene is loaded
    void Awake()
    {
        if (systemScore == null)
        {
            DontDestroyOnLoad(gameObject);
            systemScore = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start to called at the first frame of object
    void Start()
    {
        ShowScore(); //set score when it start
    }
    
    public void ShowScore()
    {
        Player1Point.text = "Player1 : " + ScoreManager.scoreManager.playerScore[0].currentScore;
        Player2Point.text = "Player2 : " + ScoreManager.scoreManager.playerScore[1].currentScore;
    }
}
