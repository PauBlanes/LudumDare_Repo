using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SacrificeWeapon : MonoBehaviour {

    private GameObject popup;

    public List<GameObject> buttons = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        popup = GameObject.FindGameObjectWithTag("SacrificePopup");
        popup.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.Escape) && popup.activeInHierarchy)
            popup.SetActive(false);       
    }

    void Sacrifice()
    {
        Time.timeScale = 0;
        popup.SetActive(true);
    }
    public void EndSacrifice()
    {
        Time.timeScale = 1;
        popup.SetActive(false);
    }

    public void Choice(int weapon)
    {        
        
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
}
