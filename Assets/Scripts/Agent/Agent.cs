using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    public GameObject sight;
    public GameObject agentBullet;

    public Transform player;
    public Transform agentFirePos;

    public List<Material> agentColors;
    public List<Transform> points;

    public float fireRate = 0.5f;
    private float nextFire = 0.0f;

    public NavMeshAgent agent;

    private void Update()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject clone = Instantiate(agentBullet, agentFirePos.position, agentFirePos.rotation);
            Destroy(clone, 1);
        }

        transform.LookAt(player);
        
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.SetDestination(points[Random.Range(0, points.Count)].position);
        }
    }

    private void OnMouseEnter()
    {
        gameObject.GetComponent<Renderer>().material = agentColors[1];
    }

    private void OnMouseExit()
    {
        gameObject.GetComponent<Renderer>().material = agentColors[0];
    }
}
