using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {
    public int myPlayerNum = 0;
    public List<GameObject> spawns = new List<GameObject>();

	// Use this for initialization
	void Start ()
    {
        SetSpawns();
    }

    public void SetSpawns()
    {
        
        spawns.AddRange(GameObject.FindGameObjectsWithTag("Spawn"));
        if (myPlayerNum == 1)
        {
            transform.position = spawns[0].transform.position;
        }

        if (myPlayerNum == 2)
        {
            transform.position = spawns[1].transform.position;
        }

        if (myPlayerNum == 3)
        {
            transform.position = spawns[2].transform.position;
        }

        if (myPlayerNum == 4)
        {
            transform.position = spawns[3].transform.position;
        }
    }

    public void ResetPos()
    {
        Debug.Log("we are calling spawns.");
        transform.position = new Vector3(spawns[myPlayerNum].transform.position.x, spawns[myPlayerNum].transform.position.y, spawns[myPlayerNum].transform.position.z);
    }

}
