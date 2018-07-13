using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    public GameObject deathParticles;

    private Appearance appear;
    private Motor motor;
    private Inputs input;
    private RestartGame restart;

	// Use this for initialization
	void Start ()
    {
        appear = GetComponent<Appearance>();
        motor = GetComponent<Motor>();
        input = GetComponent<Inputs>();
        restart = FindObjectOfType<RestartGame>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Tile")
        {
            if (collision.gameObject.GetComponent<Renderer>().material.color != appear.cols[appear.colSelector]) //if the square we hit is not black.
            {
                if (appear.colSelector != 0) //if our square is not white.
                {
                    if (collision.gameObject.GetComponent<Renderer>().material.color != appear.cols[5]) //and if that tile is not a black tile at the time we collide...
                    {
                        //KILL PLAYER
                        //disable motor
                        //enable death effect
                        //start a countdown timer to respawn
                        //etc
                        Debug.Log("Player" + appear.myPlayerNum + " touched bad square"); //we should die here!
                        GameObject particles = Instantiate(deathParticles);
                        particles.transform.up = transform.up;
                        particles.transform.position = gameObject.transform.position;
                        
                        //input.enabled = false;
                        motor.enabled = false;
                        this.gameObject.SetActive(false);
                        restart.StartCoroutine(restart.Reset());
                        
                        


                    }
                }
            }
        }

        //Debug.Log(collision.gameObject.GetComponent<Renderer>().material.color);
    }



}
