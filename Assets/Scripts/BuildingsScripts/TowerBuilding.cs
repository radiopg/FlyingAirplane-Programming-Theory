using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilding : Building
{
    public GameObject tower;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(tower, SetLocationXZ(4.33f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
