using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void loadScene(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void quit()
    {

         Application.Quit();
    }

    public void resetTime()
    {
        Time.timeScale = 1;
    }

}
