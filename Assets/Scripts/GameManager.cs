using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    // Speeds
    public float speedPlayer = 20;
    public float speedRoad = 40;
    public float speedEnemy = 20;

    // Scores
    private float distanceRecord = 0;
    private float distance = 0;
    private float disDiffChange = 1000;

    private int difficulty = 1;

    public float spawnDelay = 2;
    public float repeatRate = 2;
    public bool gameOver = true;

    public AudioSource playerAudio;

    public Button buttonStartGame;
    public Text textPlay;
    public Text textDistance;
    public Text textRecord;
    public Text textGameOver;
    public Vector3 playerInitialPos = new Vector3(0,0,0); 
    public Vector3 playerInitialRot = new Vector3(0,0,0);     

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();

        textPlay.text = "Jogar";
        textDistance.text = "Distância: ";
        distanceRecord = 0;
    }

    // Update is called once per frame
    void Update()
    { 
        if(!gameOver){
            updateDistance();
        }

        if(distance/difficulty > disDiffChange){
            difficulty++;
            Debug.Log(difficulty);
            repeatRate -= 0.2f;
            speedRoad += 5;
            speedEnemy += 5;
        }
    }

    public float getDistance(){
        return distance;
    }

    public void setDistance(float d){
        distance = d;
    }

    public void startGame(){
        distance = 0;
        
        //Reset Player's position on restart
        GameObject player = GameObject.Find("Player");
        player.transform.position = playerInitialPos;
        player.transform.eulerAngles  = playerInitialRot;

        //Destroy enemy clones on restart
        var clones = GameObject.FindGameObjectsWithTag ("Enemy");
        foreach (var clone in clones){
            Destroy(clone);
        }

        // Reset the texts and buttons
        textDistance.gameObject.SetActive(true);
        buttonStartGame.gameObject.SetActive(false);
        textGameOver.gameObject.SetActive(false);
        gameOver = false;

        playerAudio.Play();
    }
    public void endGame(){
        gameOver = true;
        textGameOver.gameObject.SetActive(true);
        textRecord.gameObject.SetActive(true);
        textPlay.text = "Recomeçar";
        playerAudio.Stop();
        buttonStartGame.gameObject.SetActive(true);
        if(distance > distanceRecord){
            distanceRecord = distance;
            textRecord.text = "Record: " + distanceRecord.ToString("F1") + " m";
        }
    }

    void updateDistance(){
         // Get the distance form GameManager, refresh it and show it in the text.
            
            distance += (speedPlayer + speedRoad) * Time.deltaTime;
            textDistance.text = "Distância: " + distance.ToString("F1") + " m";
    }

}
