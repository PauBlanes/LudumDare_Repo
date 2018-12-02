using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class UIManager {    

    public Image[] lockIcons;

    public Image[] selectedFrames;
    private int selectedIndex;

    public Text[] ammoTexts;
    public Text revolverText;

    public Image[] removed;

	public void UnlockWeapon(int index)
    {
        lockIcons[index].enabled = false;
        if (index == 3)
            revolverText.text = " / 6";
    }
    public void SelectWeapon(int index)
    {
        selectedFrames[selectedIndex].GetComponent<Image>().enabled = false;
        selectedFrames[index].GetComponent<Image>().enabled = true;    
        selectedIndex = index;        
    }
    public void UpdateScore(Weapon w)
    {
        switch (w.type)
        {          
            case Weapon.WeaponType.Metralleta:
                ammoTexts[0].text = w.ammo.ToString();
                break;
            case Weapon.WeaponType.Revolver:
                ammoTexts[3].text = Mathf.Clamp((6-w.GetRevolverAmmo()),0,6).ToString();
                break;
            case Weapon.WeaponType.Lanzagranadas:
                ammoTexts[2].text = w.ammo.ToString();
                break;
            case Weapon.WeaponType.Francotirador:
                ammoTexts[1].text = w.ammo.ToString();
                break;
            default:                
                break;
        }
    }
    public void ShowRemoved (int index)
    {
        removed[index - 1].GetComponent<Image>().enabled = true;
    }
}
