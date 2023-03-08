using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static float playerScore;
    public static float duckCount;
    public GameObject Duck;
    public GameManager gm;
    //public static float enemyScore;
    public TextMeshProUGUI playerScoreText;
    // public TextMeshProUGUI enemyScoreText;
    public TextMeshProUGUI timerText;

    //GameObject tile;

    public float levelTimer = 60;
    public float levelTimerAlt;

    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0;
        //enemyScore = 0;
        playerScoreText.gameObject.SetActive(false);
        //enemyScoreText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        levelTimer = levelTimer - Time.deltaTime;
        levelTimerAlt = Mathf.Round(levelTimer);
        timerText.text = levelTimerAlt.ToString();
       
            
            //levelTimer = 60;
            playerScoreText.gameObject.SetActive(true);
            //enemyScoreText.gameObject.SetActive(true);
            //timerText.gameObject.SetActive(false);
            playerScoreText.text = "Player Score: " + playerScore.ToString();
            //enemyScoreText.text = "Enemy Score: " + enemyScore.ToString();
        
    

    }
    public void IncrementScore()
    {
        playerScore += 1;
        playerScoreText.text = playerScore.ToString();
        duckCount-=1;
    }
    public void makeDucks(){
        if (duckCount<50)
        {
            // This will instantiate and launch 100 prefabs of the banana car.
            for (int i = 0; i < 50; i++)
            {
                GameObject ducky = Instantiate(Duck, gameObject.transform.position, Quaternion.identity);
                float rotXAmount = Random.Range(-89, -10);
                float rotYAmount = Random.Range(0, 360);
                ducky.transform.Rotate(rotXAmount, rotYAmount, 0);
                Rigidbody rb = ducky.GetComponent<Rigidbody>();
                //rb.AddForce(ducky.transform.forward * 1000);
                duckCount +=1;
                Debug.Log(duckCount);

                //Destroy(ducky, 2f);
            }
        } 
    }
}