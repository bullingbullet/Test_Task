using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    private float mouseX;
    private float mouseY;
    private readonly float mouseSense = 200f;

    [SerializeField] private Transform player;
    [SerializeField] private Transform camLook;

    [SerializeField] private List<Material> agentColors;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        CameraRotate();

        CameraLook();
    }

    private void CameraRotate()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSense * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSense * Time.deltaTime;

        player.Rotate(mouseX * Vector3.up);

        transform.Rotate(-mouseY * Vector3.right);
    }

    private void CameraLook()
    {
        if (Physics.Raycast(transform.position, transform.forward * 2000, out RaycastHit hit))
        {
            camLook.position = Vector3.Lerp(camLook.position, hit.point, Time.deltaTime * 40);
        }
    }
}
