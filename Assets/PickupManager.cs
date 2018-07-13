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
        //StartCoroutine(PlacePickup());
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (ammoOnMap.Count == maxPickups)
        {
            StopCoroutine(PlacePickup());
        }
        
        ammoOnMap.AddRange(GameObject.FindGameObjectsWithTag("PickupSpawn"));
	}

    public IEnumerator PlacePickup()
    {
        for (int i = 0; i < maxPickups; i++)
        {
            GameObject ammoClone = Instantiate(ammoObj);
            ammoClone.transform.position = pickupSpawns[Random.Range(0, pickupSpawns.Count)].transform.position;
            ammoOnMap.Add(ammoClone);
            yield return new WaitForSeconds(3);
        }

    }

    public void Enable ()
    {
        gameObject.SetActive(true);
    }
}
