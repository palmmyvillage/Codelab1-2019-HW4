using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouchGround : MonoBehaviour
{
    //set Type for what number of player this object is
    public Player_Info player;
    
    //set number to take reference
    public int playerNumber;
    
    //start
    void Start()
    {
        //set it so it's easier to mention player
        player = PlayerDatabase.playerDatabase.playerInfo[playerNumber - 1];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Player"))
        {
            player.jumpEnable = true;
            player.isJumping = false;
        }
    }//check when collisionEnter to toggle enableJump every time

    public void OnTriggerStay2D(Collider2D other) //check collisionStay to enable jump in PlayerController
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Player"))
        {
            player.jumpEnable = true;
            player.isJumping = false;
        }
    }

    private void OnTriggerExit2D(Collider2D  other) //check collisionExit to disable jump in PlayerController
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Player"))
        {
            player.jumpEnable = false;
        }
    }
}
