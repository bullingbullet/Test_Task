using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentBullet : MonoBehaviour
{
    Vector3 lastPos;

    public float punchForce = 5f;
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
                GameObject player = hit.collider.gameObject;
                player.GetComponent<Rigidbody>().AddForce(Vector3.back * punchForce, ForceMode.Impulse);
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            
        }
        lastPos = transform.position;
    }
}
