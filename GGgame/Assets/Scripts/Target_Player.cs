using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.AI;

public class Target_Player : MonoBehaviour {
    private UnityEngine.AI.NavMeshAgent agent;
    public GameObject player;
    // Use this for initialization
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = player.transform.position;
    }
}
