using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 SetLocationXZ(float height)
    {
        Vector3 newlocation = new Vector3(Random.Range(-50,51), height, Random.Range(-50, 51));
        return newlocation;
    }
}
