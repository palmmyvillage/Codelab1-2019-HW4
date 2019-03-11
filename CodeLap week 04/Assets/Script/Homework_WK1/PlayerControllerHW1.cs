using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControllerHW1 : MonoBehaviour
{
    //set variable to store Player's ScoreText
    public Text Player1Point;
    public Text Player2Point;
    
    //set variable for storing button for each player
    public Player[] Player;
    
    //set variable for storing force to move Player
    public float vLimit;
    public float forceInput;
    public float jumpInput;
    public float gravity;
    
    //set gameEnd variable
    public bool gameEnd = false;

    // Update is called once per frame
    void Update()
    {
        ControlPlayer(0);
        ControlPlayer(1);
        
        ScoreController();

        if (gameEnd == true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                print("restart");
                SceneManager.LoadScene("HomeWork_WK1");
                Time.timeScale = 1.0f;
            }
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            print("quit");
            Application.Quit();
        }
    }
    
    //set function to move each player
    public void ControlPlayer(int playerNumber) //number of player
    {
        Player[playerNumber].player.gravityScale = gravity;
        
        float ySpeed = Player[playerNumber].player.velocity.y; // always update yspeed
        
        Vector2 newForce = new Vector2(); //the force we will add to our player
        
        //when press button player move
        if (Input.GetKey(Player[playerNumber].Left)) //move left
        {
            newForce.x -= forceInput;
        }
        
        if (Input.GetKey(Player[playerNumber].Right)) //move right
        {
            newForce.x += forceInput;
        }
        
        //set limit to moving Horizontal
        if (Player[playerNumber].player.velocity.x >= vLimit)
        {
            Player[playerNumber].player.velocity = new Vector2(vLimit,ySpeed);
        }
        else if (Player[playerNumber].player.velocity.x <= -vLimit)
        {
            Player[playerNumber].player.velocity = new Vector2(-vLimit, ySpeed);
        }
        
        //Jumping 
        if (Player[playerNumber].jumpEnable == true)
        {
            if (Input.GetKeyDown(Player[playerNumber].Up)) //jump
            {
                print("Kray");
                newForce.y += jumpInput;
            }
        }
        
        Player[playerNumber].player.AddForce(newForce);
    }

    public void ScoreController()
    {
        Player1Point.text = "Player1 : " + Player[0].score;
        Player2Point.text = "Player2 : " + Player[1].score;
    }
}

[System.Serializable]
//set up player class to assign button
public class Player
{
    public string name;
    public Rigidbody2D player;
    public KeyCode Up;
    public KeyCode Left;
    public KeyCode Right;
    public bool jumpEnable;
    public int score;
}
