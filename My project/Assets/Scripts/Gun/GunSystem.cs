using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSystem : MonoBehaviour
{
    // Gun stats 
    public int damage; 
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;

    // bools
    bool shooting, readyToShoot, reloading;

    // reference
    public Camera fpsCam; 
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy; 

    // Graphics
    public GameObject muzzleFlash, bulletHoleGraphic;
    //public CamShake camShake; 
    public float camShakeMagnitude, camShakeDuration;

    private void Awake()
    {
        bulletsLeft = magSize;
        readyToShoot = true;
    }

    private void Update()
    {
        MyInput();
    }

    // get inputs
    private void MyInput()
    {
        // hold to shoot else tap to shoot
        if (allowButtonHold) 
        {shooting = Input.GetKey(KeyCode.Mouse0);}
        else 
        {shooting = Input.GetKeyDown(KeyCode.Mouse0);}

        // reload conditions
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magSize && !reloading)
        {Reload();}

        // shoot conditions
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTap; 
            Shoot();
        }

    }

    

    // shoot func
    private void Shoot()
    {
        readyToShoot = false;       // not allow to shoot when already shooting

        // spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        // calculate direction with spread
        Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);

        // Raycast 
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out rayHit, range, whatIsEnemy))
        {
            Debug.Log(rayHit.collider.name);

           /* if (rayHit.collider.CompareTag("Enemy"))
            {rayHit.collider.GetComponent<ShootingAi>().TakeDamage(damage);} */
        }

        // shake camera
        //camShake.Shake(camShakeDuration, camShakeMagnitude);

        // graphics
        Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.Euler(0, 180, 0));
        Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        bulletsLeft--;
        bulletsShot--;

        Invoke("ResetShot", timeBetweenShooting);

        // automatic, shoot repidly
        if (bulletsShot > 0 && bulletsLeft > 0)
        {Invoke("Shoot", timeBetweenShots);}
    }

    private void ResetShot()
    {
        readyToShoot = true;
    }

    // reload func
    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        bulletsLeft = magSize; 
        reloading = false;
    }
}
