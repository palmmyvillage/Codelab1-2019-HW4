using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarManagerHW1 : MonoBehaviour
{
    public float xMin;
    public float xMax;

    public float yMin;
    public float yMax;

    private float zOrigin = -0.6f;

    public int maxSpawn;

    public GameObject Controller;
    public GameObject endPanel;
    public Text winner;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawn(int spawnTimes)
    {
        if (maxSpawn > 0)
        {
            for (int i = 0; i <= spawnTimes; i++)
            {
                GameObject newStar = Instantiate(Resources.Load<GameObject>("Prefab/HW1_Prefab/Star_Prefab"));
                newStar.GetComponent<Transform>().position =
                    new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), zOrigin);
            }
            
            maxSpawn -= 1;
        }
    }

    public void gameEnd()
    {
        if (maxSpawn <= 0)
        {
            StartCoroutine(endGame());
        }
    }

    IEnumerator endGame() //set to pause game after the last Star got captured
    {
        yield return 0;
        if (GameObject.FindGameObjectWithTag("Star") == null)
        {
            int P1score = Controller.GetComponent<PlayerControllerHW1>().Player[0].score;
            int P2score = Controller.GetComponent<PlayerControllerHW1>().Player[1].score;
            
            endPanel.SetActive(true);
            if (P1score > P2score)
            {
                endPanel.GetComponent<Image>().color = new Color(0.5f,0.0f,0.0f,0.6f);
                winner.text = "Player1 Win";
                winner.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            }
            else if (P1score < P2score)
            {
                endPanel.GetComponent<Image>().color = new Color(0.0f,0.0f,0.5f,0.6f);
                winner.text = "Player2 Win";
                winner.color = new Color(0.2f, 0.4f, 1.0f, 1.0f);
            }
            else if (P1score == P2score)
            {
                endPanel.GetComponent<Image>().color = new Color(0.0f,0.0f,0.0f,0.6f);
                winner.text = "Draw";
                winner.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
            }
            Time.timeScale = 0.0f;
        }

        Controller.GetComponent<PlayerControllerHW1>().gameEnd = true;
    }
}
