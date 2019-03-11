using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Record : MonoBehaviour
{
    public Text recordText;
    
    // Start is called before the first frame update
    void Start()
    {
        ScoreManager record = ScoreManager.scoreManager;

        recordText.text =
            "Record : \n" +
            "Player 1\t\t\t" + record.P1_winNumber + " Wins\n" +
            "Player 2\t\t\t" + record.P2_winNumber + " Wins\n" +
            "Draws\t\t\t\t" + record.drawNumber + "\n" +
            "High Score\t\t" + record.highScore_record + " [ " + record.highScoreWinner_record + " ]";

    }

    void OnEnable()
    {
        ScoreManager record = ScoreManager.scoreManager;

        recordText.text =
            "Record : \n" +
            "Player 1\t\t\t" + record.P1_winNumber + " Wins\n" +
            "Player 2\t\t\t" + record.P2_winNumber + " Wins\n" +
            "Draws\t\t\t\t" + record.drawNumber + "\n" +
            "High Score\t\t" + record.highScore_record + " [ " + record.highScoreWinner_record + " ]";
    }
}
