using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    public Transform waypointParent;
    public float moveSpeed = 2f;
    public float stoppingDistance = 1f;

    public Transform[] waypoints;
    private int currentIndex = 1;

    private NavMeshAgent agent;

    // Use this for initialization
    void Start()
    {
        waypoints = waypointParent.GetComponentsInChildren<Transform>();

        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();

    }

    void OnDrawGizmosselected()
    {
        //if waypoints is not null AND waypoints is not empty
        if (waypoints != null && waypoints.Length > 0)
        {


            //Debug big circle and line that show where cube is going and trigger of waypoint
            // Get current waypoint
            Transform point = waypoints[currentIndex];
            // Draw line from position to waypoint
            Gizmos.color = Color.red;

            Gizmos.DrawLine(transform.position, point.position);
            // Draw stopping distance sphere
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(point.position, stoppingDistance);
            // Draw gravity sphere
            //Gizmos.color = Color.cyan;
            //Gizmos.DrawWireSphere(point.position, gravityDistance);

        }
    }
    void Patrol()
    {
        // 1 - Get the current waypoint
        Transform point = waypoints[currentIndex];
        // 2 - Get distance from waypoint
        float distance = Vector3.Distance(transform.position, point.position);
        // 2.1 - If distance is less than gravity distance
        //if(distance < gravityDistance)
        //{
        //    rigid.useGravity = false;
        //}
        //else
        //{
        //    rigid.useGravity = true;
        //}
        // 3 - If distance is less than stopping distance
        if (distance < stoppingDistance)
        {
            currentIndex++;

            if (currentIndex >= waypoints.Length)
            {
                currentIndex = 1;
            }
            // 4 - Move to next waypoint
        }

        // 5 translate enemy towards current waypoint
        //transform.position = Vector3.MoveTowards(transform.position, point.position, moveSpeed * Time.deltaTime);
        //transform.LookAt(point.position);
        agent.SetDestination(point.position);
    }

}
