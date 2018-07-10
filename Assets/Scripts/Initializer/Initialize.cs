using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Initialize : MonoBehaviour {
    public int _countdownTime = 1; //set in inspector: how long is the countdown before the game begins?

    public int maxPlayers;
    public int _playerNum = 0; //the number assigned to the player.
    public List<GameObject> thePlayers = new List<GameObject>(); // the list of the players in the lobby.
    public GameObject player; //the player object we will spawn 

    public Inputs playerInput; //a reference to the input script on the player
    private UIManager UI; //ref to the UI script
    public PickupManager pickups;
    


    public void Start()
    {
        UI = FindObjectOfType<UIManager>(); //tell unity how to find the UI gameobject
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetButtonDown("Fire1") && thePlayers.Count < maxPlayers)
        {
            thePlayers.Add(player);
            Debug.Log("Number of Players " + thePlayers.Count);

        }
        else if (Input.GetButtonDown("Fire1") && thePlayers.Count >= maxPlayers)
        {
            thePlayers.Clear();
            
        }

        /*if (Input.GetButton("Fire2"))
        {
            for (int i = thePlayers.Count-1; i > 0; i--)
            {
                thePlayers.Remove(player);
            }
            //thePlayers.Remove(player);
            Debug.Log("Number of Players " + thePlayers.Count);
        } */

        if (Input.GetButtonDown("Fire3") && thePlayers.Count > 0)
        {
            for (int i = 0; i < thePlayers.Count; i++)
            {
                _playerNum++;
                GameObject newPlayer = Instantiate(player);
                newPlayer.name = "Player" + _playerNum;
                newPlayer.tag = "Player" + _playerNum;
                newPlayer.GetComponent<Inputs>().myPlayerNum = _playerNum;
                newPlayer.GetComponent<Appearance>().myPlayerNum = _playerNum;
                newPlayer.GetComponent<SpawnPoint>().myPlayerNum = _playerNum;

                
                
            }

            GetComponent<Initialize>().enabled = false;
            UI.DisableMainMenu();
            StartCoroutine(UI.EnableCountdown());
            pickups.Enable();
            
        }

	}

}
