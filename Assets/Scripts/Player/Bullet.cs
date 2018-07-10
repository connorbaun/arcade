using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float timer = 0;
    public float timeBeforeDestruction = 3;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {

        timer += Time.deltaTime;

        if (timer >= timeBeforeDestruction)
        {
            Destroy(gameObject);
        }
	}
}
