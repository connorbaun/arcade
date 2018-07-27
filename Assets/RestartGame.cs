using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartGame : MonoBehaviour {
    public int restartTime = 3;
    public SpawnPoint spawn;
    public Ammo ammo;
    public Appearance appear;
    public Health health;
    private List<TileColor> tiles = new List<TileColor>();
    private List<Motor> players = new List<Motor>();
    private UIManager UI;

	// Use this for initialization
	void Start ()
    {
        tiles.AddRange(FindObjectsOfType<TileColor>());
        UI = FindObjectOfType<UIManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator Reset()
    {
        //FIND ALL PLAYER CHARACTERS CURRENTLY IN THE MATCH
        players.AddRange(FindObjectsOfType<Motor>()); //collect the current player objs in the game rn

        //WAIT FOR A FEW SECONDS WHILE PLAYERS ARE FROZEN IN PLACE AND TILES ARE AT THEIR CURRENT COLOR SET (PLAYERS CAN SEE HOW THEY DIED, ETC.)
        yield return new WaitForSeconds(restartTime); //wait a bit

        //AFTER WAITING FOR A BIT, THE COUNTDOWN UI WILL ENABLE AND BEGIN
        StartCoroutine(UI.EnableCountdown(restartTime)); //start the coroutine which actually performs the countdown onscreen
        foreach (Motor player in players)
        {
            player.GetComponent<SpawnPoint>().SetSpawns(); //reset their spawn locations
            player.GetComponent<Appearance>().DefaultColor(); //reset their colors back to white.

        }
        //AT THE SAME TIME, RESET ALL THE COLORED BLOCKS TO THE ORIGINAL BLACK COLOR.
        foreach (TileColor tile in tiles) //find each tile on the map
        {
            tile.GetComponent<Renderer>().material.color = appear.cols[5]; //reset its color back to colselct 5 which is default black
        }


        //DURING THE COUNTDOWN TEXT, WE SET THE PLAYER CONTROLS TO UNLOCK AT THE SAME RATE THAT THE COUNTDOWN HAPPENS (restartTime)
        yield return new WaitForSeconds(restartTime);//wait for the same amount of time as the countdown 

        //UNLOCK ALL PLAYERS CONTROLS AFTER THE restartTime HAS FINISHED. THIS SHOULD COINCIDE WITH THE COUTNDOWN UI SINCE THEY BOTH USE restartTime
        foreach (Motor player in players) //for each player obj in the game rn
        {
            player.GetComponent<Inputs>().enabled = true; //reenable their inputs
            player.GetComponent<Motor>().enabled = true; //re-enable their players to move
        }



    }

}
