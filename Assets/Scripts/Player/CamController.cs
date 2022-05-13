using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public static float mouseX, mouseY;

    public float mouseSense = 200f;

    public Transform player;
    public Transform camLook;

    public List<Material> agentColors;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSense * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSense * Time.deltaTime;

        player.Rotate(mouseX * Vector3.up);

        transform.Rotate(-mouseY * Vector3.right);

        CamLook();
    }

    private void CamLook()
    {
        Ray ray = new Ray(transform.position, transform.forward * 2000);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            camLook.position = Vector3.Lerp(camLook.position, hit.point, Time.deltaTime * 40);
        }
    }
}
