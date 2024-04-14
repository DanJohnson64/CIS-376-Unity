using UnityEngine;

//Required components for Enemy Object
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(TouchingDirections))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Damageable))]

public class EnemyController : MonoBehaviour
{
    //Game Component attributes
    protected Rigidbody2D rigidBody;
    protected TouchingDirections touchingDirections;
    protected Animator animator;
    protected Damageable damageable;    
    public DetectionZone attackZone;
    

    /// <summary>
    /// Class properties
    /// setters will set value to animator also 
    /// </summary>
    public float moveSpeed = 3f;
    public float walkStopRate = 0.4f;
    public bool _hasTarget = false;
    protected float attackTargetXPosition;
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



    // Moving direction detection getter and setter
    protected Vector2 moveDirectionVector = Vector2.right;
    public enum movableDirection {right, left, up, down};
    private movableDirection _moveDirection;
    public movableDirection MoveDirection
    
    {
        get{return _moveDirection;}
        set{
            if(_moveDirection != value)
            {
                gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);

                if(value == movableDirection.right)
                {
                    moveDirectionVector = Vector2.right;
                }
                else if(value == movableDirection.left)
                {
                    moveDirectionVector = Vector2.left;
                }
                else if(value == movableDirection.up)
                {
                    moveDirectionVector = Vector2.up;
                }
                else if(value == movableDirection.down)
                {
                    moveDirectionVector = Vector2.down;
                }
                

            }
            _moveDirection = value;}
    } 

    //Initialization 
    public void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        touchingDirections = GetComponent<TouchingDirections>();
        animator = GetComponent<Animator>(); 
        damageable = GetComponent<Damageable>();
    }

    // Physics related functions and behavior, fixed interval update. 
    public void FixedUpdate()
    {   


    }

    // called every frame
    void Update()
    {
        //if detected player collider, hasTarget is true
        hasTarget = attackZone.detectedColliders.Count > 0;
        attackTargetXPosition = attackZone.detectedColliders[0].transform.position.x;

        //set timer for attack cooldown
        if (AttackCooldown > 0)
        { 
            AttackCooldown -= Time.deltaTime; 
        } 
    }

    protected void flipDirection()
    {
        if (MoveDirection == movableDirection.right)
        {
            MoveDirection = movableDirection.left;
        }
        else if (MoveDirection == movableDirection.left)
        {
            MoveDirection = movableDirection.right;
        }


    }

    public void OnHit(int damage, Vector2 knockBack)
    {
        //set knock back for attack
        rigidBody.velocity = new Vector2(knockBack.x, rigidBody.velocity.y + knockBack.y);
    }

    public void OnDie()
    {

    }
  
}
