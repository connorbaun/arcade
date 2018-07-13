using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
    public GameObject bullet;
    public int bulletVelocity;



    private Appearance appear;

	// Use this for initialization
	void Start ()
    {
        appear = GetComponent<Appearance>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Projectile()
    {
        
        
            GameObject bulletClone = Instantiate(bullet);
            bulletClone.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 3);
            bulletClone.GetComponent<Renderer>().material.color = appear.cols[appear.colSelector];
            bulletClone.GetComponent<Rigidbody>().AddForce(bulletVelocity * transform.forward);
        

    }
}
