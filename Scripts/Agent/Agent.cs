using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    [SerializeField] private GameObject sight;
    [SerializeField] private GameObject agentBullet;

    [SerializeField] private Transform player;
    [SerializeField] private Transform agentFirePos;

    [SerializeField] private List<Material> agentColors;

    [SerializeField] private List<Transform> points;

    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private float nextFire;

    [SerializeField] private NavMeshAgent agent;

    private void Update()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject _AgentBullet = Instantiate(agentBullet, agentFirePos.position, agentFirePos.rotation);
            Destroy(_AgentBullet, 1);
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
