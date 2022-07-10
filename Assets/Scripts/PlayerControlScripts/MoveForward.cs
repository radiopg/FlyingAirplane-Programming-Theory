using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{

    private GameObject ground;
    private float groundBoundX;
    private float groundBoundZ;
    private float groundBoundY;
    private GameObject playerObj;
    private PlayerController playerSpeed;
    private float speed = 10.0f;
    


    // Start is called before the first frame update
    void Start()
    {
        ground = GameObject.FindGameObjectWithTag("Ground");
        groundBoundX = ground.GetComponent<Renderer>().bounds.size.x / 2;
        groundBoundZ = ground.GetComponent<Renderer>().bounds.size.z / 2;
        groundBoundY = groundBoundX;

        playerObj = GameObject.FindGameObjectWithTag("Player");
        playerSpeed = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();


        transform.rotation = playerObj.transform.rotation;
        
    }


    // Update is called once per frame
    void Update()
    {
        
        speed = speed + playerSpeed.speed;

        transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);

        if (transform.position.x > groundBoundX ||
            transform.position.x < -groundBoundX ||
            transform.position.z > groundBoundZ ||
            transform.position.z < -groundBoundZ)
        {
            Destroy(gameObject);
        }

        if (transform.position.x > groundBoundX ||
                transform.position.x < -groundBoundX ||
                transform.position.z > groundBoundZ ||
                transform.position.z < -groundBoundZ)
        {
             Destroy(gameObject);
        }

        if(transform.position.y < 0 || transform.position.y > groundBoundY)
        {
            Destroy(gameObject);
        }
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Either Primary or Seconday Fire Hit Something!");
        if (collision.gameObject.CompareTag("Player"))
        {
            //Destroy(gameObject);
            Debug.Log("You Hit A Bullet");
        }
    }
}
