using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField] private GameObject bullet;

    [SerializeField] private Transform firePos;
    [SerializeField] private Transform camLook;

    public void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firePos.LookAt(camLook);

            Instantiate(bullet, firePos.position, firePos.rotation);

            SaveLog.SaveLine("Shoot");
        }
    }
}
