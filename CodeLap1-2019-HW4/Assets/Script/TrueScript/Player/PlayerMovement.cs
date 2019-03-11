using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //initiate the player_info to refer from
    private Player_Info[] player;
    
    // Start is called before the first frame update
    void Start()
    {
        //initiate where it can be refer
        player = PlayerDatabase.playerDatabase.playerInfo;
        
        //add Gravity (only when the scene start)
        //use for so that it apply to any number of players
        for (int i = 0; i < player.Length; i++)
        {
            playerGravity(i);
            playerRotation(i);
        }
    }

    // Update is called once per frame
    void Update()
    {        
        //add Abilities to Run and Jump
        //use for so that it apply to any number of players
        for (int i = 0; i < player.Length; i++)
        {
            playerRunning(i);
            playerJumping(i);
        }
    }

    //set function to move each player with force
    public void playerRunning(int playerNumber) //set how player run
    {   
        //set class runningSpeed;
        float runningSpeed =  PlayerDatabase.playerDatabase.getClassRunningForce(player[playerNumber].ChosenClass);
        //set class xLimit
        float xSpeedLimit = PlayerDatabase.playerDatabase.getClassRunningLimit(player[playerNumber].ChosenClass);
        // set updated speed
        float xSpeed = player[playerNumber].rigidBody.velocity.x;
        float ySpeed = player[playerNumber].rigidBody.velocity.y; 

        //force will always add to player
        Vector2 newForce = new Vector2();

        //Horizontal movement
        if (Input.GetKey(player[playerNumber].Left)) //move left
        {
            //newForce.x -= Class[player[playerNumber].chosenClasses].runningForce;
            newForce.x -= runningSpeed;
        }

        if (Input.GetKey(player[playerNumber].Right)) //move right
        {
            newForce.x += runningSpeed;
        }

        //set limitSpeed to moving Horizontal
        if (xSpeed >= xSpeedLimit)
        {
            player[playerNumber].rigidBody.velocity = new Vector2(xSpeedLimit, ySpeed);
        }
        else if (xSpeed <= -xSpeedLimit)
        {
            player[playerNumber].rigidBody.velocity = new Vector2(-xSpeedLimit, ySpeed);
        }

        // add new force to object to move
        player[playerNumber].rigidBody.AddForce(newForce);
    }

    public void playerGravity(int playerNumber) //set how player affected by gravity
    {
        //get class gravity
        float gravity = PlayerDatabase.playerDatabase.getClassGravityInput(player[playerNumber].ChosenClass);
        //set gravity
        player[playerNumber].rigidBody.gravityScale = gravity;
    }

    public void playerJumping(int playerNumber) //set how player Jump
    {
        float xSpeed = player[playerNumber].rigidBody.velocity.x;
        float ySpeed = player[playerNumber].rigidBody.velocity.y;

        //set bool to use for this one
        bool jumpEnable = player[playerNumber].jumpEnable;
        KeyCode jumpButton = player[playerNumber].Up;

        float glidingInput = PlayerDatabase.playerDatabase.getClassGlidingInput(player[playerNumber].ChosenClass); //get gliding

        //force will always add to player
        Vector2 newForce = new Vector2();
        newForce.y = glidingInput;

        //check if jump possible or not
        if (Input.GetKeyDown(jumpButton)) //jump
        {
            if (player[playerNumber].jumpEnable == true)
            {
                player[playerNumber].rigidBody.velocity = new Vector2(xSpeed, 0); //nullifyFallingForce first
                StartCoroutine(applyJumpingForce(playerNumber));
            }
        }

        //check if during jump or not
        if (player[playerNumber].isJumping == true)
        {
            if (Input.GetKey(jumpButton))
            {
                player[playerNumber].rigidBody.AddForce(newForce);
            }
        }
    }

    public void playerRotation(int playerNumber) // set ability to rotate player
    {
        player[playerNumber].rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    
    //use this with PlayerJumping to apply jumping force after nullification
    IEnumerator applyJumpingForce(int playerNumber) //nullify falling velocity before making A JUMP
    {
        yield return 0; // wait 1 frame
        
        //set jumpingInput
        float jumpInput = PlayerDatabase.playerDatabase.getClassJumpingForce(player[playerNumber].ChosenClass);
        
        //force will always add to player
        Vector2 newForce = new Vector2();
        
        newForce.y += jumpInput;
        player[playerNumber].rigidBody.AddForce(newForce);
        player[playerNumber].isJumping = true;
    }
}
