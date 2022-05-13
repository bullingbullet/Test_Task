using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public GameObject bullet;

    public Transform firePos;
    public Transform camLook;

    public void Shoot()
    {
        firePos.LookAt(camLook);

        Instantiate(bullet, firePos.position, firePos.rotation);

        SaveLog.sw.WriteLine("Shoot");
    }
}
