using UnityEngine;

public class AgentBullet : MonoBehaviour
{
    private Vector3 lastPos;

    private readonly float punchForce = 7f;
    private readonly float speed = 30f;

    private void Start()
    {
        lastPos = transform.position;
    }

    private void Update()
    {
        AgentBulletTranslatePosition();

        AgentBulletCheckHits();
    }

    private void AgentBulletTranslatePosition()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }

    private void AgentBulletCheckHits()
    {
        if (Physics.Linecast(lastPos, transform.position, out RaycastHit hit))
        {
            if (hit.collider.name == "player")
            {
                hit.collider.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.back * punchForce, ForceMode.Impulse);
            }
            Destroy(gameObject);
        }

        lastPos = transform.position;
    }
}
