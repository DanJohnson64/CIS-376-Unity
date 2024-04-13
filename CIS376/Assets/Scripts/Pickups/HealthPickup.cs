using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthRestore = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If an entity enters this collider and has a damageable component 
        Damageable damageable= collision.GetComponent<Damageable>();

        if(damageable)
        {
            damageable.heal(healthRestore);
            Destroy(gameObject);
        }
    }
}
