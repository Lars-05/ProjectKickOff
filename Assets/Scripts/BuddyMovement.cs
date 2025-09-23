using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class BuddyMovement : MonoBehaviour
{
    
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer buddySpriteRenderer;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private movement movement;
    private Vector3 pointOnNavMesh = Vector3.zero;
    private float lastXCoord = 0;
    float timePassed = 0;

    private void Awake()
    {
        Debug.Log("ffffff");
        lastXCoord = this.transform.position.x;
        GetPointOnNavMesh();
    }
    
        
    private void OnEnable()
    {
        GetPointOnNavMesh();
    }

    private void GetPointOnNavMesh()
    {
        pointOnNavMesh = movement.GetRandomPoint(); 
        agent.SetDestination(pointOnNavMesh);
      
    }

    public void Update()
    {
        Debug.Log("aa");
        float currentXCoord = this.transform.position.x;
        if (currentXCoord > lastXCoord)
        {
            buddySpriteRenderer.flipX = true;
        }
        else if (currentXCoord < lastXCoord)
        {
            buddySpriteRenderer.flipX = false;
        }
        
        lastXCoord = currentXCoord;
        
        if (Vector3.Distance(agent.transform.position, pointOnNavMesh) < 20f)
        {
            animator.SetBool("isMoving", false);
            int randNumber = Random.Range(5, 10);
            timePassed += Time.deltaTime;
            if (timePassed > randNumber)
            {
                GetPointOnNavMesh();
            }
        }
        else
        {
            animator.SetBool("isMoving", true);
            timePassed = 0;
        }
    }
}