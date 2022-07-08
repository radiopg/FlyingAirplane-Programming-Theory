using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyramidBuilding : Building
{
    public GameObject pyramid;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(pyramid, SetLocationXZ(12.43409f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
