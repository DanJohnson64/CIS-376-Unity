using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(TouchingDirections))]
public class KnightController : MonoBehaviour
{
    //Game Component attributes
    Rigidbody2D rigidBody;
    TouchingDirections touchingDirections;
    Animator animator;
    public DetectionZone attackZone;

    // Class properties 
    public float walkSpeed = 3f;
    public float walkStopRate = 0.4f;
    public bool _hasTarget = false;
    public bool hasTarget{
        get
        {
            return _hasTarget;
        }        
        set
        {
            _hasTarget = value;
            animator.SetBool(AnimationStrings.hasTarget, value);
        }
    }

    public bool CanMove
    {
        get
        {
            return animator.GetBool(AnimationStrings.canMove);
        }
    }

    // Walking direction detection and set
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
    }
    private Vector2 walkDirectionVector = Vector2.right;

    //Initialization 
    public void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        touchingDirections = GetComponent<TouchingDirections>();
        animator = GetComponent<Animator>();
    }

    // Physics related fixed interval update
    public void FixedUpdate()
    {   
        if(touchingDirections.IsOnWall && touchingDirections.IsGrounded)
        {
            flipDirection();
        }

        if(CanMove)
        {
            rigidBody.velocity = new Vector2(walkSpeed * walkDirectionVector.x, rigidBody.velocity.y);
        }
        else
        {
            rigidBody.velocity = new Vector2(Mathf.Lerp(rigidBody.velocity.x,0,walkStopRate),rigidBody.velocity.y);
        }
    }

    // called every frame
    void Update()
    {
        hasTarget = attackZone.detectedColliders.Count > 0;
    }

    // switches walking direction
    private void flipDirection()
    {
        if(WalkDirection == WalkableDirection.right)
        {
            WalkDirection = WalkableDirection.left;
        }
        else if(WalkDirection == WalkableDirection.left)
        {
            WalkDirection = WalkableDirection.right;
        }
        

    }    
  
}
