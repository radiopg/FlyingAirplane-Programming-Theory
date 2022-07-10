using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteBullet : Bullets
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public override void Explode()
    {
        if (Input.GetKey(KeyCode.RightControl))
        {
            DontExplodeTilRightControlPressed();
        }
    }

    public void DontExplodeTilRightControlPressed()
    {
        GameObject expl = Instantiate(explosion, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, 5f);

        foreach (Collider nearbyObj in colliders)
        {
            Rigidbody rb = nearbyObj.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(1400f, transform.position, 5f);
            }
        }

        Destroy(gameObject);
        Destroy(expl);
    }
}
