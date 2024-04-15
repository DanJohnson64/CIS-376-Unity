using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Events;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class DeathZone : MonoBehaviour
{
     Collider2D _collider;
    public List<Collider2D> detectedColliders = new List<Collider2D>();
    

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            detectedColliders.Add(collision);                  
            GameObject entity = collision.gameObject;
            if(entity.TryGetComponent<Damageable>(out Damageable entityDamageable))
            {
                if(entityDamageable.isPLayer())
                {
                    entityDamageable.Health = 0;
                }
            }
                
            
        }

         
    }

    void OnTriggerExit2D(Collider2D collision)
    {
            if (collision != null)
        {
            detectedColliders.Remove(collision);
        }
    }
   
}
