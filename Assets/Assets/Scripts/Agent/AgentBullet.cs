using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentBullet : MonoBehaviour
{
    Vector3 lastPos;

    public static float punchForce = 900;
    public float speed;

    private void Start()
    {
        lastPos = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        RaycastHit hit;

        Debug.DrawLine(lastPos, transform.position);
        if (Physics.Linecast(lastPos, transform.position, out hit))
        {
            if (hit.collider.name == "player")
            {
                Destroy(gameObject, 0.3f);
            }
            else
            {
                Destroy(gameObject);
            }
            
        }
        lastPos = transform.position;
    }
}
