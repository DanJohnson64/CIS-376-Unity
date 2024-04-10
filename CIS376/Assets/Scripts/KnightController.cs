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
    Damageable damageable;
    
    public DetectionZone attackZone;
    public DetectionZone ledgeDetection;

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

    public float AttackCooldown
    {
        get
        {
            return animator.GetFloat(AnimationStrings.attackCooldown);
        }
        set 
        {
            animator.SetFloat(AnimationStrings.attackCooldown, Mathf.Max(value,0));
        }
    }



    // Walking direction detection and set
    private Vector2 walkDirectionVector = Vector2.right;
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

   




    //Initialization 
    public void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        touchingDirections = GetComponent<TouchingDirections>();
        animator = GetComponent<Animator>(); 
        damageable = GetComponent<Damageable>();
    }

    // Physics related functions, fixed interval update
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
        if (AttackCooldown > 0)
        { 
            AttackCooldown -= Time.deltaTime; 
        } 
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

    public void OnHit(int damage, Vector2 knockBack)
    {
        rigidBody.velocity = new Vector2(knockBack.x, rigidBody.velocity.y + knockBack.y);
    }

    public void OnNoGroundDetected()
    {
        if(touchingDirections.IsGrounded)
        {
            flipDirection();
        }
    }
  
}
