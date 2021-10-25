using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    private float xRange = 7.0f;

    
    private AudioSource playerAudio;
    public AudioClip crashSound;

    private MoveRight moveRight;
    private GameManager gameManager;
    public ParticleSystem explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //playerAudio.PlayOneShot(engineSound, 1.0f);

    }

    // Update is called once per frame
    void Update()
    {
       
        if(!gameManager.gameOver){
             //Control the Player
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * gameManager.speedPlayer);

        } else if(Input.GetKey(KeyCode.Space)){
            gameManager.startGame();
        }
        

        // Limit the bounds of where the player can go on the map, only the road
        if (transform.position.x < -xRange) {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }

    public void turnLeft(){
        transform.Translate(Vector3.left * Time.deltaTime * gameManager.speedPlayer);
    }

    public void turnRight(){
        transform.Translate(Vector3.right * Time.deltaTime * gameManager.speedPlayer);
    }

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Enemy")){
            gameManager.endGame();
            explosionParticle.Play();
            playerAudio.PlayOneShot(crashSound, 1.0f);  
            
        }
        
        
    }

}
