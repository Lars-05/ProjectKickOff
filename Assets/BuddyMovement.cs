using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class BuddyMovement : IUpdaterBase
{
    [SerializeField] private SpriteRenderer buddySpriteRenderer;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private movement movement;
    private Vector3 pointOnNavMesh = Vector3.zero;
    float timePassed = 0;

    private void Awake()
    {
        GetPointOnNavMesh();
    }

    private void GetPointOnNavMesh()
    {
        pointOnNavMesh = movement.GetRandomPoint(); 
        agent.SetDestination(pointOnNavMesh);
      
    }

    public override void SharedUpdate()
    {
        if (this.transform.position.x < pointOnNavMesh.x)
        {
            buddySpriteRenderer.flipX = true;
        }
        else
        {
            buddySpriteRenderer.flipX = false;
        }
        Debug.unityLogger.Log(Vector3.Distance(agent.transform.position, pointOnNavMesh));
        if (Vector3.Distance(agent.transform.position, pointOnNavMesh) < 50f)
        {
            int randNumber = Random.Range(5, 10);
            timePassed += Time.deltaTime;
            if (timePassed > randNumber)
            {
                GetPointOnNavMesh();
            }
        }
        else
        {
            timePassed = 0;
        }
    }
    
}