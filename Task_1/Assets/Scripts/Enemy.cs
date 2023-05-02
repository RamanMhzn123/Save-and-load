using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float speed = 1f;
    public float rotationSpeed = 10f;
    public float minDistanceToWaypoint = 1.5f;
    public Transform[] waypoints;

    bool isStopped = false;
    Vector3 direction;
    IEnumerator starter;

    int currentWaypointIndex;

    void Start()
    {
        currentWaypointIndex = Random.Range(0, waypoints.Length);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (starter != null) //if there is a coroutine running 
                StopCoroutine(starter); //stop

            starter = ResumeEnemyMovement();
            StartCoroutine(starter);
        }

        if (!isStopped)
        {
            direction = waypoints[currentWaypointIndex].position - transform.position;

            if (direction.magnitude <= minDistanceToWaypoint)
            {
                    currentWaypointIndex = Random.Range(0, waypoints.Length);
            }

            MoveEnemy();
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

        //Debug.DrawRay(transform.position, newDirection);
    }

    private IEnumerator ResumeEnemyMovement()
    {
        yield return new WaitForSeconds(0.5f);
        isStopped = !isStopped;
    }
}
