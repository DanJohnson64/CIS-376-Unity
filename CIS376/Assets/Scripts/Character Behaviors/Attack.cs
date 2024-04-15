using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Attack : MonoBehaviour
{
    Collider2D attackCollider;
    public int attackDamage;
    public Vector2 knockBack = Vector2.zero;


    private void Awake()
    {
        attackCollider = GetComponent<Collider2D>();
    }

    private void FixedUpdate()
    {
        if(transform.localScale.x != transform.parent.localScale.x)
        {
            transform.localScale *= new Vector2(-1, 1);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check to see if target is damageable
        Damageable damageable = collision.GetComponent<Damageable>();

        if(damageable != null)
        {
            //If parent localscale is positive, do nothing. Otherwise reverse knockBack x direction
            Vector2 deliveredKnockback = transform.parent.localScale.x > 0 ? knockBack : new Vector2(-knockBack.x, knockBack.y);

            //Hit target
            bool gotHit = damageable.takeDamage(attackDamage, deliveredKnockback);
            if(gotHit)
            {
                Debug.Log(collision.name + " hit for " + attackDamage);
            }
        }
    }


}
