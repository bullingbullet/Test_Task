using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public GameObject sight;

    public List<Material> agentColors;

    public float speed;
    public float reload;

    private void OnMouseEnter()
    {
        gameObject.GetComponent<Renderer>().material = agentColors[1];
    }

    private void OnMouseExit()
    {
        gameObject.GetComponent<Renderer>().material = agentColors[0];
    }
}
