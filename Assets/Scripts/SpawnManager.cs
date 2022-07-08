using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //private GameObject playerObj;
    public GameObject primaryFirePrefab;
    public GameObject secondaryFirePrefab;
    private GameObject emptyGameObjInFrontOfPlayer;
    private Vector3 spawnPos;
    
    

    // Start is called before the first frame update
    void Start()
    {
        //emptyGameObjInFrontOfPlayer = GameObject.FindGameObjectWithTag("GhostObjFrontOfPlayer");


    }

    // Update is called once per frame
    void Update()
    {
        spawnPos = emptyGameObjInFrontOfPlayer.transform.position;
    }

    void fireFromPlayer()
    {

        Instantiate(primaryFirePrefab, spawnPos, primaryFirePrefab.transform.rotation);
        Instantiate(secondaryFirePrefab, spawnPos, secondaryFirePrefab.transform.rotation);
    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("You ran into something!");
    }
}
