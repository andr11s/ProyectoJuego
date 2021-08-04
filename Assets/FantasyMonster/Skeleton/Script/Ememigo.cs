using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ememigo : MonoBehaviour
{
    Transform player;
    UnityEngine.AI.NavMeshAgent nav;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("pj").transform;
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(player.position);
    }
}

