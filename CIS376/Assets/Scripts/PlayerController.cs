using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    Vector2 moveInput;
    
    
    //Component objects
    Rigidbody2D rigidBody;
    Animator animator;

    [SerializeField] private bool _isMoving = false;

    //Sets isMoving parameter in Animator 
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
        rigidBody.velocity = new Vector2(moveInput.x * walkSpeed, rigidBody.velocity.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        IsMoving = moveInput != Vector2.zero;

        setFacingDirection(moveInput);
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
