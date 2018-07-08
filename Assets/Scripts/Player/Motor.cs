using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour {
    public Rigidbody rb;
    private Vector3 velocity = Vector3.zero;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}

    public void FixedUpdate()
    {
        PerformMovement();
    }

    public void GetVelocity(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    public void PerformMovement()
    {
        rb.MovePosition(transform.position + velocity * Time.fixedDeltaTime);
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
