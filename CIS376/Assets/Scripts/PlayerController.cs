using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(TouchingDirections))]
public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float jumpSpeed = 10f;
    public bool IsAlive
    {
        get
        {
            return animator.GetBool(AnimationStrings.isAlive);
        }
        
    }
    Vector2 moveInput;
    
    
    //Component objects
    Rigidbody2D rigidBody;
    Animator animator;
    TouchingDirections touchingDirections;

    public float currentMoveSpeed{
    
        get
        {
            if(canMove)
            {
                    if(IsMoving && !touchingDirections.IsOnWall)
                {
                    return walkSpeed;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
    }

    //Sets isMoving parameter in Animator 
    [SerializeField] private bool _isMoving = false;    
    public bool IsMoving { 
        get
        {
            return _isMoving;
        } 
        private set
        {        
            _isMoving = value;
            animator.SetBool(AnimationStrings.isMoving, value);        
        } 
    }

    public bool canMove{
        get{
            return animator.GetBool(AnimationStrings.canMove);
        }
    }

    //player facing
    public bool _isFacingRight = true;
    public bool isFacingRight { 
        get
        {              
            return _isFacingRight;

        }
        private set
        {
            //flip local scale to make player face opposite direction 
            if(_isFacingRight != value)
            {
                transform.localScale *= new Vector2(-1,1);
            }
            _isFacingRight = value;
        }
     
    }

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        touchingDirections = GetComponent<TouchingDirections>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(moveInput.x * currentMoveSpeed, rigidBody.velocity.y);
        animator.SetFloat(AnimationStrings.yVelocity, rigidBody.velocity.y);
      
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        if(IsAlive)
        {
            IsMoving = moveInput != Vector2.zero; 
            setFacingDirection(moveInput);
        }
        else
        {
            IsMoving = false;
        }
        
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        //TODO also check for player alive
        if(context.started && touchingDirections.IsGrounded && canMove)
        {
            animator.SetTrigger(AnimationStrings.jumpTrigger);
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {        
        if(context.started)
        {
            animator.SetTrigger(AnimationStrings.attackTrigger);
        }        
    }

    private void setFacingDirection(Vector2 moveInput)
    {
        if(moveInput.x > 0 && !isFacingRight)
        {
            isFacingRight = true;
        }
        else if(moveInput.x < 0 && isFacingRight)
        {
            isFacingRight = false;
        }

    }

   
}
