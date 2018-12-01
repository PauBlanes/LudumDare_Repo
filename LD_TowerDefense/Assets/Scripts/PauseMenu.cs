using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class PauseMenu : MonoBehaviour {

    //Menu de pausa
    public GameObject pauseMenu;

    // Use this for initialization
    void Start () {
        pauseMenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        //PAUSE MENU
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(!pauseMenu.activeInHierarchy);
            GetComponent<PlayerController>().enabled = !GetComponent<PlayerController>().enabled;
            if (Time.timeScale == 0)
                Time.timeScale = 1;
            else
                Time.timeScale = 0;
        }
    }

    public void Restart()
    {
        EditorSceneManager.LoadScene(EditorSceneManager.GetActiveScene().name);
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        GetComponent<PlayerController>().enabled = true;
        Time.timeScale = 1;
    }

    public void Exit()
    {
        EditorSceneManager.LoadScene("MainMenu");
    }

    public void HowToPlay()
    {
        Debug.Log("Show info");
    }
}
