using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.1f;
    private float rotationSpeed = 50.0f;
    private bool gameOver = false;
    private bool canShootPrimary = true;
    private bool canShootSecondary = true;
    private float groundBoundX;
    private float groundBoundZ;
    private GameObject ground;
    private Rigidbody playerRb;
    private GameObject emptyGameObjInFrontOfPlayer;
    

    
    //public GameObject primaryFirePrefab;
    //public GameObject secondaryFirePrefab;
    private Vector3 spawnPos;
    private Quaternion playerRotation;

    private NormalBullet bulletPrimary;
    private RemoteBullet bulletSecondary;




    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        ground = GameObject.FindGameObjectWithTag("Ground");
        groundBoundX = ground.GetComponent<Renderer>().bounds.size.x / 2;
        groundBoundZ = ground.GetComponent<Renderer>().bounds.size.z / 2;
        emptyGameObjInFrontOfPlayer = GameObject.FindGameObjectWithTag("GhostObjFrontOfPlayer");

        bulletPrimary = GameObject.Find("SpawnForBullets").GetComponent<NormalBullet>();
        bulletSecondary = GameObject.Find("SpawnForBullets").GetComponent<RemoteBullet>();

    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        PlayerShoot();
        CheckPlayerOutOfBounds();
        

    }

    //moves player
    void MovePlayer()
    {
        //player movement input
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            float rollRight = rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
            transform.Rotate(0,0, -rollRight);
            
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            float rollLeft = rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
            transform.Rotate(0, 0, -rollLeft);
            
            
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            float pitchDown = rotationSpeed * Time.deltaTime * Input.GetAxis("Vertical");
            transform.Rotate(pitchDown, 0, 0);
            
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            float pitchUp = rotationSpeed * Time.deltaTime * Input.GetAxis("Vertical");
            transform.Rotate(pitchUp, 0, 0);
            
        }


        //speed up
        if (Input.GetKey(KeyCode.W))
        {
            speed += 0.1f;
        }

        //speed down
        if (Input.GetKey(KeyCode.S))
        {
            speed -= 0.1f;
            if (speed < 0.1f)
            {
                speed = 0.1f;
            }
        }

        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void PlayerShoot()
    {
        
        emptyGameObjInFrontOfPlayer = GameObject.Find("emptyObjectInFrontOfPlayer");
        spawnPos = emptyGameObjInFrontOfPlayer.transform.position;
        

        if (Input.GetKey(KeyCode.Space) && canShootPrimary)
        {
            bulletPrimary.Shoot(spawnPos);
            canShootPrimary = false;
            StartCoroutine("PrimaryCountDown");
            
        }

        if (Input.GetKey(KeyCode.RightShift) && canShootSecondary)
        {

            bulletSecondary.Shoot(spawnPos);
            canShootSecondary = false;
            StartCoroutine("SecondaryCountDown");
            
        }
        
    }

    //checks if player has left play area
    void CheckPlayerOutOfBounds()
    {
        //if outside x cord game over
        if ((transform.position.x > groundBoundX) || (transform.position.x < -groundBoundX))
        {
            gameOver = true;
            Debug.Log("Game Over! by Out of Bounds");
        }

        //if outside z cord gameover
        if ((transform.position.z > groundBoundZ) || (transform.position.z < -groundBoundZ))
        {
            gameOver = true;
            Debug.Log("Game Over! by Out of Bounds");
        }

        
    }

    

    //checks for any collisions on player versus objects in game
    private void OnCollisionEnter(Collision collision)
    {
        gameOver = true;
        Debug.Log("Game Over! by Hitting Something.");
    }

    private IEnumerator PrimaryCountDown()
    {
        canShootPrimary = false;
        float duration = 1.0f;
        float normalizedTime = 0;
        while (normalizedTime <= 1f)
        {
            normalizedTime += Time.deltaTime / duration;
            yield return null;
            
        }
        canShootPrimary = true;

    }
    private IEnumerator SecondaryCountDown()
    {
        canShootSecondary = false;
        float duration = 5.0f;
        float normalizedTime = 0;
        while (normalizedTime <= 1f)
        {
            normalizedTime += Time.deltaTime / duration;
            
            yield return null;
            
        }
        canShootSecondary = true;
    }
}
