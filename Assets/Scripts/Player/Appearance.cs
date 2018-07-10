using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appearance : MonoBehaviour {

    public int myPlayerNum;
    public int colSelector = 0;
    public List<Color> cols = new List<Color>();

    private Ammo ammo;

	// Use this for initialization
	void Start ()
    {
        ammo = GetComponent<Ammo>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        gameObject.GetComponent<Renderer>().material.color = cols[colSelector];


        /* if (myPlayerNum == 1)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }

        if (myPlayerNum == 2)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;

        }

        if (myPlayerNum == 3)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;

        }

        if (myPlayerNum == 4)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.yellow;

        } */


    }

    public void SwapColor()
    {
        if (colSelector >= cols.Count - 1)
        {
            colSelector = 0;
        }
        else
        {
            colSelector += 1;
        }
    }

    public void BecomeWhite()
    {
        if (ammo.currentAmmo >= 1 && colSelector!= 0)
        {
            colSelector = 0;
            ammo.currentAmmo -= 1;
        }

    }

    public void BecomeBlue()
    {
        colSelector = 1;
    }

    public void BecomePink()
    {
        colSelector = 2;
    }

    public void BecomeGreen()
    {
        colSelector = 3;
    }

    public void BecomeRed()
    {
        colSelector = 4;
    }
}
