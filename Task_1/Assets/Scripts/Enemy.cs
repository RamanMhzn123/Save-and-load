using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float speed = 1f; 
    public float rotationSpeed = 10f;
    public float minDistanceToWaypoint = 1.5f;
    public Transform[] waypoints;

    public bool isMoving;
    Vector3 direction;
    IEnumerator starter;

    int currentWaypointIndex;

    void Start()
    {
        currentWaypointIndex = Random.Range(0, waypoints.Length);
        starter = ResumeEnemyMovement();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //Space
        {
            isMoving = !isMoving;

            if(isMoving)
                StartCoroutine(starter);
            else
                StopCoroutine(starter);
        }
    }

    private IEnumerator ResumeEnemyMovement()
    {
        while (true)
        {
            MoveEnemy();
            ChangeWaypoint();
            yield return null; 
        }
    }

    void MoveEnemy()
    {
        // Calculate new direction to move towards
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, rotationSpeed * Time.deltaTime, 0.0f);
        // Rotate towards the new direction
        transform.rotation = Quaternion.LookRotation(newDirection);
        // Move the enemy in the new direction
        transform.position += transform.forward * speed * Time.deltaTime;

        //transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, speed * Time.deltaTime);
        //Debug.DrawRay(transform.position, newDirection);
    }

    void ChangeWaypoint()
    {
        direction = waypoints[currentWaypointIndex].position - transform.position; //direction

        if (direction.magnitude <= minDistanceToWaypoint) //if close to waypoint
        {
            currentWaypointIndex = Random.Range(0, waypoints.Length); //change to random waypoint
        }
    }
}
