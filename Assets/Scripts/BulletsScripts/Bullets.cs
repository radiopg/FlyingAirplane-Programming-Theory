using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{

    public GameObject bulletPrefab;
    public GameObject explosion;
    public bool insideTrigger = false;
    public float speedOfBullet = 25.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot(Vector3 spawnPos)
    {
        Instantiate(bulletPrefab, spawnPos, Quaternion.identity);
    }

    private void OnCollisionEnter()
    {
        Debug.Log("bulletCOLLIDED");
        GameObject expl = Instantiate(explosion, bulletPrefab.transform.position, Quaternion.identity) as GameObject;
        Destroy(bulletPrefab);
    }

    public virtual void Explode()
    {

    }
    
}
