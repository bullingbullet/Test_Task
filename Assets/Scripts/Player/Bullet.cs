using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public new GameObject particleSystem;

    public int speed;

    Vector3 lastPos;

    private void Start()
    {
        lastPos = transform.position;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        RaycastHit hit;

        Debug.DrawLine(lastPos, transform.position);
        if (Physics.Linecast(lastPos, transform.position, out hit))
        {
            if (hit.collider.name == "agent")
            {
                Destroy(hit.collider.gameObject);
                
                SaveLog.sw.WriteLine("Hit agent", true);  
            }

            Instantiate(particleSystem, lastPos, gameObject.transform.rotation);

            if (!hit.collider.gameObject.CompareTag("AgentBullet"))
            {
                Destroy(gameObject);
            }
        }
        lastPos = transform.position;
    }
}
