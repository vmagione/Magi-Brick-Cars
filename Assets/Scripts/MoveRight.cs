using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour
{
    //private PlayerController playerController;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        //playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameManager.gameOver){
            if(gameObject.CompareTag("Road")){
                transform.Translate(Vector3.right * Time.deltaTime * gameManager.speedRoad);
            } 
            
        }
    }
}
