using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appearance : MonoBehaviour {

    public int myPlayerNum;

	// Use this for initialization
	void Start ()
    {
       
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (myPlayerNum == 1)
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

        }
    }
}
