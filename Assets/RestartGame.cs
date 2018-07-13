using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartGame : MonoBehaviour {
    public int restartTime = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator Reset()
    {
        yield return new WaitForSeconds(restartTime);
        Debug.Log("restart");
        SceneManager.LoadScene("level1");
        
    }

}
