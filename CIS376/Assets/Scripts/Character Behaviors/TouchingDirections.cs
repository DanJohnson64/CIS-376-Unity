using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class TouchingDirections : MonoBehaviour
{
    public ContactFilter2D castFilter;
    RaycastHit2D[] groundHits = new RaycastHit2D[5];
    RaycastHit2D[] wallHits = new RaycastHit2D[5];
    RaycastHit2D[] ceilingHits = new RaycastHit2D[5];
    CapsuleCollider2D touchingCollider;
    Animator animator;

    public float groundDistance = 0.05f;
    public float wallDistance = 0.2f;
    public float ceilingDistance = 0.05f;
    private Vector2 wallCheckDirection => gameObject.transform.localScale.x >0 ? Vector2.right : Vector2.left;

    [SerializeField] private bool _isGrounded = true;
    public bool IsGrounded { get{return _isGrounded;} 
        private set
        {
            _isGrounded = value;
            animator.SetBool(AnimationStrings.isGrounded,value);
        } 
    }

    [SerializeField] public bool _isOnWall = false;
    public bool IsOnWall { get{return _isOnWall;} 
        private set
        {
            _isOnWall = value;
            animator.SetBool(AnimationStrings.isOnWall,value);
        } 
    }
    

    [SerializeField] public bool _isOnCeiling = false;  

    public bool IsOnCeiling { get{return _isOnCeiling;} 
        private set
        {
            _isOnCeiling = value;
            animator.SetBool(AnimationStrings.isOnCeiling,value);
        } 
    }

    void Awake()
    {
        touchingCollider = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
    }
   

    // Update is called once per frame
    void FixedUpdate()
    {
        IsGrounded = touchingCollider.Cast(Vector2.down, castFilter, groundHits, groundDistance) > 0;
        IsOnWall = touchingCollider.Cast(wallCheckDirection, castFilter, wallHits, wallDistance) > 0;
        IsOnCeiling = touchingCollider.Cast(Vector2.up, castFilter, ceilingHits, ceilingDistance) > 0;
    }
}