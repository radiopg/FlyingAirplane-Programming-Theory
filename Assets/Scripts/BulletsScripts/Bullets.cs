using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{

    public GameObject bulletPrefab;
    public GameObject explosion;
    public bool insideTrigger = false;
    public float speedOfBullet = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (insideTrigger)
        {
            Instantiate(explosion, bulletPrefab.transform.position, Quaternion.identity);
            explosion.transform.localScale += new Vector3(1/60, 1/60, 1/60);
            
            
            
        }
        else
        {
            Instantiate(explosion, bulletPrefab.transform.position, Quaternion.identity);
            explosion.transform.localScale += new Vector3(1 / 60, 1 / 60, 1 / 60);
        }
        */
    }

    public void Shoot(Vector3 spawnPos)
    {
        
        Instantiate(bulletPrefab, spawnPos, Quaternion.identity);
        bulletPrefab.transform.Translate(Vector3.forward * speedOfBullet, Space.World);
    }

    private void OnCollisionEnter()
    {
        GameObject expl = Instantiate(explosion, bulletPrefab.transform.position, Quaternion.identity) as GameObject;
        Destroy(bulletPrefab);
        Destroy(expl, 3);
    }

    public virtual void Explode()
    {

    }
    
}
