using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    private float downBound = -15;

    private GameManager gameManager;

    //private PlayerController playerController;

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
            if(gameObject.CompareTag("Enemy")){
                transform.Translate(Vector3.back * Time.deltaTime * gameManager.speedEnemy);
            } 
            
        }

        
        if(transform.position.z < downBound && gameObject.CompareTag("Enemy")){
            Destroy(gameObject);
        }
        

    }
}
