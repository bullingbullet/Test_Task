using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField] private GameObject bullet;

    [SerializeField] private Transform firePos;
    [SerializeField] private Transform camLook;

    public void Shoot()
    {
        firePos.LookAt(camLook);

        Instantiate(bullet, firePos.position, firePos.rotation);

        SaveLog.SaveLine("Shoot");
    }
}
