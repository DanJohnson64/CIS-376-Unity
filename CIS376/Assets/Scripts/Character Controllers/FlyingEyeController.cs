using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

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
        else
        {
            //dead flyer falls to the ground
            rigidBody.gravityScale = 2f;
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        }
    }

    private void flight()
    {
        //Get direction to next waypoint
        Vector2 directionToNextWaypoint = (nextWaypoint.position - transform.position).normalized;
        
        //Find distance to waypoint. if 0 will not move
        float distance = Vector2.Distance(nextWaypoint.position, transform.position);

        //check to see if need to flip direction
        flightFacingDirection();

        //move to waypoint
        
        rigidBody.velocity = directionToNextWaypoint * flightSpeed;

        //see if we need to switch waypoints
        if(distance <= wayPointReachedZone)
        {
            
            if(wayPointNumber > wayPoints.Count -1)
            {
                wayPointNumber = 0;
            }
            
            nextWaypoint = wayPoints[wayPointNumber];
            Debug.Log("waypoint number is " + wayPointNumber);
            Debug.Log("waypoint count is " + wayPoints.Count);
            wayPointNumber++;
        }


    }

    private void flightFacingDirection()
    {
        //if facing right, flip
        if (transform.localScale.x > 0)
        {            
            if (rigidBody.velocity.x < 0)
            {
                flipDirection();
            }
        }
        //if facing right, flip
        else
        {
            if (rigidBody.velocity.x > 0)
            {
                flipDirection();
            }
        }
    }

}
