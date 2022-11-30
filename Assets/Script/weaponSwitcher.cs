using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponSwitcher : MonoBehaviour
{
    public int selected;
    public int TotalFire;

    public playerMovementScript pmove;
    public Canvas Gun_UI;

    void Start()
    {
        SelectWeapon();
    }
    
    void Update()
    {
        int currentSelection = selected;

        if(Input.GetButtonDown("Fire2"))
        {
            if (selected >= transform.childCount - 1)
                selected = 0;
            else
                selected++;
        }

        //switching weapon
        if(currentSelection != selected)
        {
            SelectWeapon();
        }

        //Speed controller
        if (selected == 0)
        {
            pmove.speed = 1f;
            Gun_UI.enabled = false;
        }
        else
        {
            pmove.speed = 0.5f;
            Gun_UI.enabled = true;
        }
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if (i == selected)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
