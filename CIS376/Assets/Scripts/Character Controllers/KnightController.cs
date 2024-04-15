using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightController : EnemyController
{
    public DetectionZone ledgeDetection;
    
    
    
    // Class properties 


    // Override FixedUpdate
    new public void FixedUpdate()
    {   
        if(hasTarget && CanMove)
        {
            rigidBody.velocity = new Vector2(moveSpeed * attackTargetPosition.x, rigidBody.velocity.y);
        }
        if(touchingDirections.IsOnWall && touchingDirections.IsGrounded)
        {
            flipDirection();            

        }

        if(CanMove)
        {
            rigidBody.velocity = new Vector2(moveSpeed * moveDirectionVector.x, rigidBody.velocity.y);
        }
        else
        {
            rigidBody.velocity = new Vector2(Mathf.Lerp(rigidBody.velocity.x,0,walkStopRate),rigidBody.velocity.y);
        }
    }
    

    public void OnNoGroundDetected()
    {
        if(touchingDirections.IsGrounded)
        {
            flipDirection();
        }
    }
  
}
