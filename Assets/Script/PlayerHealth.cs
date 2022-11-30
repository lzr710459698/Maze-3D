using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float Health;
    public Canvas HealthUICanvas;
    public Canvas gunScopeCanvas;
    public Slider healthSlider;
    
    public playerMovementScript pm;
    public mouseLookScript ml;
    public spawnBOTScript sb;
    public cameraShakeScript shakeCam;
    public Animator EndGameAnimation;
    public weaponSwitcher weaponSwitcherScript;

    bool isRotate;

    public int TotalKills;
    public int BulletsUsed;
    public float HowlongPlayed;

    public Text TotalKills_txt;
    public Text BulletsUsed_txt;
    public Text TimePlayed_txt;
    public Text YourScore_txt;
    public Text HighScore_txt;

    private void Start()
    {
        healthSlider.maxValue = Health;
        healthSlider.value = Health;

        TotalKills = 0;
        BulletsUsed = 0;
        HowlongPlayed = 0f;

        HighScore_txt.text = PlayerPrefs.GetInt("highScore", 0).ToString();
    }

    private void Update()
    {
        healthSlider.value = Health;

        HowlongPlayed += Time.deltaTime;

        if(Health <= 0)
        {
            sb.enabled = ml.enabled = pm.enabled = false;

            if (isRotate == false)
            {
                Cursor.lockState = CursorLockMode.None;
                StartCoroutine(shakeCam.Shake(0.5f, 0.3f));
                this.transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, 60f));

                HowlongPlayed /= 60f;
                string temp = HowlongPlayed.ToString("0.00") + " Min.Sec";
                TimePlayed_txt.text = temp;

                TotalKills_txt.text = TotalKills.ToString();

                BulletsUsed = weaponSwitcherScript.TotalFire;
                BulletsUsed_txt.text = BulletsUsed.ToString();

                if (TotalKills == 0) TotalKills = 1;

                float score = TotalKills * HowlongPlayed * 5;
                YourScore_txt.text = score.ToString("0");

                gunScopeCanvas.enabled = false;
                HealthUICanvas.enabled = false;
                EndGameAnimation.SetBool("isEnd", true);

                setHighestScore();

                isRotate = true;
            }
        }
    }

    void setHighestScore()
    {
        if(int.Parse(HighScore_txt.text) < int.Parse(YourScore_txt.text))
        {
            HighScore_txt.text = YourScore_txt.text;
            PlayerPrefs.SetInt("highScore", int.Parse(YourScore_txt.text));
        }
    }
}
