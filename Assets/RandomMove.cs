using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class RandomMove : MonoBehaviour
{
    public float minTime = 2;
    public float maxTime = 5;
    public GameObject groundPlatform;
    private NavMeshAgent navAgent;
    private Bounds bounds;

    private void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        bounds = groundPlatform.GetComponent<Renderer>().bounds;
    }

    private void Update()
    {
        if (navAgent.hasPath == false || navAgent.remainingDistance < 1.0f)
        {
            float waitTime = Random.Range(minTime, maxTime);
            GetComponent<Renderer>().material.color = Color.blue;
            Invoke("PickRandomDestination", waitTime);
        }
    }

    void PickRandomDestination()
    {
        float rx = Random.Range(bounds.min.x, bounds.max.x);
        float rz = Random.Range(bounds.min.z, bounds.max.z);
        Vector3 rPos = new Vector3(rx, transform.position.y, rz);
        navAgent.SetDestination(rPos);
        GetComponent<Renderer>().material.color = Color.red;
    }
    
}
