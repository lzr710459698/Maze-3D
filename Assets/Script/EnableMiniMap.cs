using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableMiniMap : MonoBehaviour
{
    public Canvas MiniMapCanvas;
    public KeyCode code;
    public bool isEnable;

    void Update()
    {
        if (Input.GetKeyDown(code))
        {
            if(isEnable == false)
            {
                MiniMapCanvas.enabled = true;
                isEnable = true;
            }
            else
            {
                MiniMapCanvas.enabled = false;
                isEnable = false;
            }
        }
        
    }
}
