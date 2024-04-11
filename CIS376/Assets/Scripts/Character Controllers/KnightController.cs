using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightController : EnemyController
{
    public DetectionZone ledgeDetection;
    
    
    // Class properties 
 



    // Walking direction detection and set
    /*private Vector2 walkDirectionVector = Vector2.right;
    public enum WalkableDirection {right, left};
    private WalkableDirection _walkDirection;
    public WalkableDirection WalkDirection
    
    {
        get{return _walkDirection;}
        set{
            if(_walkDirection != value)
            {
                gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);

                if(value == WalkableDirection.right)
                {
                    walkDirectionVector = Vector2.right;
                }
                else if(value == WalkableDirection.left)
                {
                    walkDirectionVector = Vector2.left;
                }

            }
            _walkDirection = value;}
    }*/

    // Override FixedUpdate
    new public void FixedUpdate()
    {   
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

    private void flipDirection()
    {
        if(MoveDirection == movableDirection.right)
        {
            MoveDirection = movableDirection.left;
        }
        else if(MoveDirection == movableDirection.left)
        {
            MoveDirection = movableDirection.right;
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
