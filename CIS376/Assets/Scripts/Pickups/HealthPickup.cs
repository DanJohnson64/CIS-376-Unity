using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickup
{
    public int healthRestore = 1;

    AudioSource pickupSource;

    private void Awake()
    {
        pickupSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If an entity enters this collider and has a damageable component 
        Damageable damageable= collision.GetComponent<Damageable>();

        if(damageable && damageable.isPLayer() && damageable.Health < damageable.MaxHealth)
        {
            damageable.heal(healthRestore);
            AudioSource.PlayClipAtPoint(pickupSource.clip, gameObject.transform.position, pickupSource.volume);
            Destroy(gameObject);
        }
    }
}
