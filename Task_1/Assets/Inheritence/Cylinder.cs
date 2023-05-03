using UnityEngine;

public class Cylinder : EnemyParent
{
    public Transform wayPoint1, wayPoint2;
    Transform waypointTarget;

    private void Awake()
    {
        waypointTarget = wayPoint1;
    }
    
    protected override void Move()
    {
        base.Move();
        
        //if not in range, move from waypoint1 to waypoint2 
        if(Vector3.Distance(transform.position, player.position) > distance)
        {
            if(Vector3.Distance(transform.position, wayPoint1.position) <= 0.01f)
            {
                waypointTarget = wayPoint2;
            }

            if (Vector3.Distance(transform.position, wayPoint2.position) <= 0.01f)
            {
                waypointTarget = wayPoint1;
            }

            transform.position = Vector3.MoveTowards(transform.position, waypointTarget.position, moveSpeed * Time.deltaTime);
        }
    }
}
