using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    private int countdownTime = 0;

    public GameObject mainUI;
    public Text numPlayUI;
    public Text instrucUI;

    public GameObject gameplayUI;
    public Text countdownUI;


    private Initialize init;

	// Use this for initialization
	void Start ()
    {
        gameplayUI.SetActive(false);
        init = FindObjectOfType<Initialize>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        numPlayUI.text = "Users in Lobby " + init.thePlayers.Count.ToString();
        instrucUI.text = "Press UP ARROW KEY to change number of players. Press SPACEBAR to launch match.";        
	}


    public void DisableMainMenu()
    {
        mainUI.SetActive(false);
    }

    public IEnumerator EnableCountdown()
    {
        gameplayUI.SetActive(true);
        countdownUI.text = "Get Ready...";
        yield return new WaitForSeconds(init._countdownTime);

        countdownUI.text = "FIGHT!!!";

        yield return new WaitForSeconds(init._countdownTime);
        countdownUI.text = " ";
       
    }
}
