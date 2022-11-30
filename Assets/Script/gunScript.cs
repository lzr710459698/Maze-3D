using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunScript : MonoBehaviour
{
    public float damage;
    public float range;
    public float fireRate;
    public int gunAmmo;
    public float waitTimeToReload;

    public Camera Gun_Cam;
    public ParticleSystem MuzzleFlash;
    public GameObject hitEffect;
    public Animator GunReload_Animation;
    public weaponSwitcher weaponSwitcherScript;

    float nextTimeToFire;
    int currentAmmo;
    bool isReloading;

    void Start()
    {
        currentAmmo = gunAmmo;
    }

    void OnEnable()
    {
        isReloading = false;
        GunReload_Animation.SetBool("Reloading", false);
    }

    void Update()
    {
        if (isReloading)
            return;

        if(gunAmmo <= 0)
        {
            StartCoroutine(reloadGun());
            return;
        }

        if (Input.GetButton("Fire1") && Time.time>=nextTimeToFire)
        {
            nextTimeToFire = Time.time + (1 / fireRate);
            Shoot();
        }
    }

    IEnumerator reloadGun()
    {
        isReloading = true;
        Debug.Log("Reloading...");
        GunReload_Animation.SetBool("Reloading", true);

        yield return new WaitForSeconds(waitTimeToReload - 0.25f);
        GunReload_Animation.SetBool("Reloading", false);

        yield return new WaitForSeconds(0.25f);
        gunAmmo = currentAmmo;
        isReloading = false;
    }

    void Shoot()
    {
        MuzzleFlash.Play();
        //gunAmmo--;
        weaponSwitcherScript.TotalFire += 1;

        RaycastHit hitInfo;
        if(Physics.Raycast(Gun_Cam.transform.position, Gun_Cam.transform.forward, out hitInfo, range))
        {
            Debug.Log(hitInfo.transform.name);

            Bot_Health target = hitInfo.transform.GetComponent<Bot_Health>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }

            GameObject hitGo = Instantiate(hitEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            Destroy(hitGo, 1f);
        }
    }

}
