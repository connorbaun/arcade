using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileColor : MonoBehaviour {
    public Appearance appear;


	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionStay(Collision collision)
    {
        //IF THE PLAYER'S COLOR IS NOT WHITE...
        if(collision.gameObject.GetComponent<Appearance>().colSelector != 0)
        {
            gameObject.GetComponent<Renderer>().material.color = collision.gameObject.GetComponent<Appearance>().cols[collision.gameObject.GetComponent<Appearance>().colSelector];
        }
           //THEN CHANGE THE TILE COLOR TO MATCH THEIR COLOR
        
    }

    /*public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Appearance>().colSelector == 0)
        {
            gameObject.GetComponent<Renderer>().material.color = collision.gameObject.GetComponent<Appearance>().cols[5];

        }

    } */

}
