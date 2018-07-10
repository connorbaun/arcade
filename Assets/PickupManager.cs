using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour {
    public List<GameObject> pickupSpawns = new List<GameObject>();
    public GameObject ammoObj;

    public List<GameObject> ammoOnMap = new List<GameObject>();

    public float timer = 0;
    public float spawnTimeMin = 5;
    public float spawnTimeMax = 8;
    public float maxPickups = 3;


	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        if (timer >= spawnTimeMin)
        {
            timer = 0;

            //PlacePickup();
            //StartCoroutine(PlacePickups());
        }

        ammoOnMap.AddRange(GameObject.FindGameObjectsWithTag("PickupSpawn"));
	}

    public void PlacePickup()
    {
        

            GameObject ammoClone = Instantiate(ammoObj);
            ammoClone.transform.position = pickupSpawns[Random.Range(0, pickupSpawns.Count)].transform.position;
        //ammoOnMap.Add(ammoClone);

    }

    public void Enable ()
    {
        this.gameObject.SetActive(true);
    }
}
