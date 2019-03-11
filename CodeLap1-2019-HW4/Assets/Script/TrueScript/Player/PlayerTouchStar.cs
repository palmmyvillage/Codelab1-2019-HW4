using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouchStar : MonoBehaviour
{   
    //set playerNumber
    public int playerNumber;

    //set boolean to prevent checking Trigger many times
    private Boolean isTouchingStar;
    
    //set update to check isTouchingStar
    void Update()
    {
        isTouchingStar = false;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isTouchingStar == false && other.CompareTag("Star"))
        {
            isTouchingStar = true;
            Destroy(other.gameObject); //destroy star
            ScoreManager.scoreManager.playerScore[playerNumber - 1].currentScore += other.GetComponent<StarScore>().score; //add score
            StarSpawner.starSpawner.spawnStar(); //spawn new star
            ScoreUI.systemScore.ShowScore(); // tell scoreUi to tell if the current score

            if (StarSpawner.starSpawner.times.maxSpawn <= 0)
            {
                if (StarSpawner.starSpawner.starCount.starGathered >= StarSpawner.starSpawner.starCount.totalStar)
                {
                    //print("Palmmy");
                    SystemController.systemController.gameEnds();
                }
            }
        }
    }
}
