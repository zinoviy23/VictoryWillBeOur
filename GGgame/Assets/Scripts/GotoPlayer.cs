using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GotoPlayer : MonoBehaviour {
    private NavMeshAgent agent;
    public GameObject player;
    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
        agent.destination = player.transform.position;
    }
}
