using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class howtoPlay : MonoBehaviour
{
    public Canvas UI, UI2;

    public void Instructions()
    {
        UI.enabled = false;
        UI2.enabled = true;
    }

    public void Back()
    {
        UI2.enabled = false;
        UI.enabled = true;
    }
}
