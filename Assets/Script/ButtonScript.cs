using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public void MainMenuBTN()
    {
        SceneManager.LoadScene("main_menu");
    }

    public void PlayAgainBTN()
    {
        SceneManager.LoadScene("scene1");
    }

    public void ExitBTN()
    {
        Application.Quit();
    }

}
