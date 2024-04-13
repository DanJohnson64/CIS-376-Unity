using Assets.Scripts.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    public UnityEvent<int,Vector2> damageableHit;
    public UnityEvent<int, int> healthChanged;
    Animator animator;
    [SerializeField] private bool isInHitStun = false;


    public bool IsHit 
    { 
        get
        {
            return animator.GetBool(AnimationStrings.isHit);
        } 
        private set
        {
            animator.SetBool(AnimationStrings.isHit, value);
        }
    }

    private float timeSinceHit = 0;
    private float hitStunTime = 0.25f;
    [SerializeField]private bool _isAlive = true;
    public bool IsAlive
    {
        get
        {
            return _isAlive;
        }
        set
        {
            _isAlive = value;
            animator.SetBool(AnimationStrings.isAlive, value);
            
        }
    }
    [SerializeField]private int _health = 100;
    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
            healthChanged?.Invoke(_health, MaxHealth);
            if(_health <= 0)
            {
                IsAlive = false;
            }
        }
    }

    [SerializeField]private int _maxHealth = 100;  

    public int MaxHealth
    {
        get
        {
            return _maxHealth;
        }
        set
        {
            _maxHealth = value;
        }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(isInHitStun)
        {
            if(timeSinceHit > hitStunTime)
            {
                isInHitStun = false;
                timeSinceHit = 0;
            }
            timeSinceHit += Time.deltaTime;
        }
        
    }

    public bool takeDamage(int damage, Vector2 knockBack)
    {
        if(IsAlive && !isInHitStun)
        {
            Health -= damage;
            isInHitStun = true;
            IsHit = true;

            //if not null, notify other subscribed components that damage was taken and to apply knock back
            damageableHit?.Invoke(damage, knockBack);

            //invoke damaged event
            CharacterEvents.characterDamaged.Invoke(gameObject, damage);
            return true;
        }

        //if unable to take damage
        return false;
    }

    public void heal(int healthRestore)
    {
        if (IsAlive && Health != MaxHealth)
        {
            int maxHeal = Mathf.Max(MaxHealth - Health,0);
            Health += Mathf.Min(maxHeal, healthRestore);

            CharacterEvents.characterHealed.Invoke(gameObject, healthRestore);
        }
    }
 
}
