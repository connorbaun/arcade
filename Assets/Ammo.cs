using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour {
    public int currentAmmo = 3;
    public int maxAmmo = 3;

	// Use this for initialization
	void Start () {
        currentAmmo = maxAmmo;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log("my ammo: " + currentAmmo);
	}


}
