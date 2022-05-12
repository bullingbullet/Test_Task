using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    public GameObject sight;

    public List<Material> agentColors;
    public List<Transform> points;

    public NavMeshAgent agent;

    private void Start()
    {
        gameObject.GetComponent<Renderer>().material = agentColors[0];
    }

    private void Update()
    {
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
