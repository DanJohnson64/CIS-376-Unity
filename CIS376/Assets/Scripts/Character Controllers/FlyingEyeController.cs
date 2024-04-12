using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlyingEyeController : EnemyController
{
    //Game Object attibutes
    public List<Transform> wayPoints;
    


    //Properties
    public float flightSpeed = 2f;
    int wayPointNumber = 0;
    Transform nextWaypoint;
    public float wayPointReachedZone = 0.1f;


    private void Start()
    {
        nextWaypoint = wayPoints[wayPointNumber];
    }

    new void FixedUpdate()
    {
        if(damageable.IsAlive)
        {
            if(CanMove)
            {
                flight();
            }
        }
    }

    private void flight()
    {
        //Get direction to next waypoint
        Vector2 directionToNextWaypoint = (nextWaypoint.position - transform.position).normalized;
        
        //Find distance to waypoint. if 0 will not move
        float distance = Vector2.Distance(nextWaypoint.position, transform.position);

        //move to waypoint
        
        rigidBody.velocity = directionToNextWaypoint * flightSpeed;

        //see if we need to switch waypoints
        if(distance <= wayPointReachedZone)
        {
            
            if(wayPointNumber >= wayPoints.Count -1)
            {
                wayPointNumber = 0;
            }
            
            nextWaypoint= wayPoints[wayPointNumber];
            Debug.Log("waypoint number is " + wayPointNumber);
            Debug.Log("waypoint count is " + wayPoints.Count);
            wayPointNumber++;
        }


    }

}
