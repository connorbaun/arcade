using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour {

    public float runSpeed = 12; //how fast does our character move around the level?
    public int myPlayerNum = 0; //(inherited from the init script) --- which player is this? 
    public int countdownTime = 0;

    private Motor motor; //reference for the Motor script attached to player. This script performs all movements and rotations.
    private Initialize init;


	// Use this for initialization
	void Start ()
    {
        //ReceiveCountdownTime(countdownTime);
        motor = GetComponent<Motor>(); //tell unity that we are referring to the motor attached to this character
        init = FindObjectOfType<Initialize>();
        StartCoroutine(DisableMotor());
	}


	
	// Update is called once per frame
	void Update ()
    {
        
        float hInput = Input.GetAxisRaw(myPlayerNum+"Horizontal"); //take player input on x-axis and store it as hInput
        float zInput = Input.GetAxisRaw(myPlayerNum+"Vertical"); //take player input on z-axis and store it as zInput

        Vector3 _strafing = transform.right * hInput; //apply input value to the x (green arrow) transform of the object
        Vector3 _running = transform.forward * zInput; //apply input value to the z (blue arrow) transform of the object

        Vector3 _velocity = (_strafing + _running) * runSpeed; //add the x and z directions together, and multiply by our movespeed for final velocity

        motor.GetVelocity(_velocity); //send the final velocity over to Motor script to perform the movement

	}

    public IEnumerator DisableMotor()
    {
        motor.enabled = false;

        yield return new WaitForSeconds(init._countdownTime);

        motor.enabled = true;
    }

}
