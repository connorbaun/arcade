using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartGame : MonoBehaviour {
    public int restartTime = 3;
    public SpawnPoint spawn;
    public Ammo ammo;
    public Appearance appear;
    private TileColor tile;

	// Use this for initialization
	void Start ()
    {
        tile = FindObjectOfType<TileColor>();
      
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator Reset()
    {
        yield return new WaitForSeconds(restartTime);

        tile.DefaultColor();
        //SceneManager.LoadScene("level1");


        
    }

}
