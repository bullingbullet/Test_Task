using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private new GameObject particleSystem;

    private readonly float speed = 50f;

    private Vector3 lastPos;

    private void Start()
    {
        lastPos = transform.position;
    }

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.forward);

        Debug.DrawLine(lastPos, transform.position);
        if (Physics.Linecast(lastPos, transform.position, out RaycastHit hit))
        {
            if (hit.collider.gameObject.CompareTag("Agent"))
            {
                Destroy(hit.collider.gameObject);
                
                SaveLog.SaveLine("Hit agent");  
            }

            if (!hit.collider.gameObject.CompareTag("AgentBullet"))
            {
                Destroy(gameObject);
            }

            Instantiate(particleSystem, lastPos, gameObject.transform.rotation);
        }
        lastPos = transform.position;
    }
}
