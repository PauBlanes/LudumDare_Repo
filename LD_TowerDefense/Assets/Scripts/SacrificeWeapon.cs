using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SacrificeWeapon : MonoBehaviour {

    private GameObject popup;

    public List<GameObject> buttons = new List<GameObject>();
    
    public bool choseSacrifice;

    GameObject baseAttacked;

    // Use this for initialization
    void Start()
    {
        popup = GameObject.FindGameObjectWithTag("SacrificePopup");
        popup.SetActive(false);

        if (SceneManager.GetActiveScene().name != "Game")
        {
            foreach (GameObject b in buttons)
            {
                b.GetComponent<Button>().enabled = false;
                b.transform.GetChild(0).GetComponent<Image>().enabled = true;
            }
        }       
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.Escape) && popup.activeInHierarchy)
            popup.SetActive(false);       
    }

    public void StartSacrifice(GameObject b)
    {
        Time.timeScale = 0;
        popup.SetActive(true);

        baseAttacked = b;
        
    }
    public void EndSacrifice()
    {
        Time.timeScale = 1;
        popup.SetActive(false);

        baseAttacked.GetComponent<Base>().KillNearEnemies();

        if (choseSacrifice)
            baseAttacked.GetComponent<Base>().health = 300;
        else
            Destroy(baseAttacked);
        
    }

    public void Choice(int weapon)
    {        
        choseSacrifice = true;  

        switch (weapon)
        {
            case 0:
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().RemoveWeapon(Weapon.WeaponType.Metralleta);                
                break;
            case 1:                
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().RemoveWeapon(Weapon.WeaponType.Francotirador);                
                break;
            case 2:                
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().RemoveWeapon(Weapon.WeaponType.Lanzagranadas);               
                break;
            case 3:                
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().RemoveWeapon(Weapon.WeaponType.Revolver);                
                break;
            default:
                break;               
        }

        buttons[weapon].GetComponent<Button>().enabled = false;
        buttons[weapon].transform.GetChild(0).GetComponent<Image>().enabled = true;
        EndSacrifice();

    }
    public void UnlockButton(int index)
    {
        buttons[index].GetComponent<Button>().enabled = true;
        buttons[index].transform.GetChild(0).GetComponent<Image>().enabled = false;        
    }
}
