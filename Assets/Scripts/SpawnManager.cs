using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //private PlayerController playerController;
    private GameManager gameManager;
    public GameObject[] enemyPrefabs;
    private float enemyXRange = 7.0f;
    

    private Vector3 obstaclePos = new Vector3(0,0,35);

    // Start is called before the first frame update
    void Start()
    {
        //playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        InvokeRepeating("SpawnEnemy", gameManager.spawnDelay, gameManager.repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy (){
        obstaclePos.x = Random.Range(-enemyXRange,enemyXRange);
        int indexEnemy =Random.Range(0,enemyPrefabs.Length);

        if(!gameManager.gameOver){
            Instantiate(enemyPrefabs[indexEnemy], obstaclePos, enemyPrefabs[indexEnemy].transform.rotation);
        }
        
    }

}
