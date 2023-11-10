using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountedTurretShoot : MonoBehaviour
{
    public GameObject bullet;
    public GameObject barrel;
    public Transform shootPoint;
    public Quaternion start;
    private Quaternion rotateTowards;
    public float timeStamp;
    public float shootCooldown;
    public float barrelSpeed;
    public bool barrelRotate, isShooting;
    public TurretSwitch turret;
    public GameObject sfx;

    private Vector3 initialLocalRotation;

    public void Start()
    {
        start = barrel.transform.localRotation;
        initialLocalRotation = barrel.transform.localRotation.eulerAngles;
    }

    public void OnShoot()
    {
        isShooting = !isShooting;
    }

    public void Update()
    {
        if (isShooting == true)
        {
            if (turret.turretActive == true)
            {
                if (Time.time > timeStamp)
                {
                    Instantiate(sfx,shootPoint.position, shootPoint.rotation);
                    Instantiate(bullet, shootPoint.position, shootPoint.rotation);
                    barrelRotate = true;
                    rotateTowards = barrel.transform.localRotation * Quaternion.Euler(0, 90, 0);
                    timeStamp = Time.time + shootCooldown;
                }
            }
        }
        if (barrelRotate == true)
        {
            barrel.transform.localRotation = Quaternion.Lerp(barrel.transform.localRotation, rotateTowards, barrelSpeed * Time.deltaTime);

            if (Quaternion.Angle(barrel.transform.localRotation, rotateTowards) < 1.0f)
            {
                barrelRotate = false;
            }
        }
    }
}
