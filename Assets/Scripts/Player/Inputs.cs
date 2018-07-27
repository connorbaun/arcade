using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour {

    public float runSpeed = 12; //how fast does our character move around the level?
    public int myPlayerNum = 0; //(inherited from the init script) --- which player is this? 
    //public int countdownTime = 0;

    private Motor motor; //reference for the Motor script attached to player. This script performs all movements and rotations.
    private Appearance appear;
    private Shoot shoot;
    private Initialize init; //reference to the initializer. this lets us take whatever we need from that obj


	// Use this for initialization
	void Start ()
    {
        //ReceiveCountdownTime(countdownTime);
        motor = GetComponent<Motor>(); //tell unity that we are referring to the motor attached to this character
        appear = GetComponent<Appearance>();
        shoot = GetComponent<Shoot>();
        init = FindObjectOfType<Initialize>(); //tell unity how to access initializer
        StartCoroutine(DisableMotor(init._countdownTime)); //right away, we want to disable the motor so players cannot move by default
	}


	
	// Update is called once per frame
	void Update ()
    {
        //MOVEMENT INPUTS
        float hInput = Input.GetAxisRaw(myPlayerNum+"Horizontal"); //take player input on x-axis and store it as hInput
        float zInput = Input.GetAxisRaw(myPlayerNum+"Vertical"); //take player input on z-axis and store it as zInput


        Vector3 _strafing = transform.right * hInput; //apply input value to the x (green arrow) transform of the object
        Vector3 _running = transform.forward * zInput; //apply input value to the z (blue arrow) transform of the object

        Vector3 _velocity = (_strafing + _running) * runSpeed; //add the x and z directions together, and multiply by our movespeed for final velocity

        motor.GetVelocity(_velocity); //send the final velocity over to Motor script to perform the movement

        //COLOR CHANGE INPUTS
        /*if (Input.GetButtonDown(myPlayerNum + "Switch"))
        {
            //appear.SwapColor();
            appear.BecomeGreen();
        } */

        if (Input.GetButtonDown(myPlayerNum + "R2")) //let player turn white at will
        {

            //call the shoot script attached to the player and fire the projectile!!!
            //appear.ResetColor();
            appear.BecomeWhite();
            //Debug.Log("i hit r2");
        }
        if (Input.GetButtonDown(myPlayerNum + "X")) //press x to turn blue
        {
            appear.BecomeBlue();
        }
        if (Input.GetButtonDown(myPlayerNum + "Square")) //press square to turn pink
        {
            appear.BecomePink();
        }
        if (Input.GetButtonDown(myPlayerNum + "Triangle")) //press triangle to turn green
        {
            appear.BecomeGreen();
        }
        if (Input.GetButtonDown(myPlayerNum + "Circle")) //press circle to turn red
        {
            appear.BecomeRed();
        }
        if (Input.GetButtonDown(myPlayerNum + "Shoot"))
        {
            shoot.Projectile();
            //Debug.Log("we shot");
        }


    }

    public IEnumerator DisableMotor(int countdown) //this function disables the motor and then waits for the countdown time before re-enabling it so we can move.
    {
        
        motor.enabled = false; //disable motor. this way we cannot move at all
        Debug.Log("we should NOT be allowed to mover");

        yield return new WaitForSeconds(countdown); //wait for whatever time we set on the initializer for countdown

        motor.enabled = true; //enable the motor after this prerequisite time has been reached.
        Debug.Log("We should now be allowed to move.");
    }



}
