using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectionZone : MonoBehaviour
{
    Collider2D _collider;
    public List<Collider2D> detectedColliders = new List<Collider2D>();
    public UnityEvent noCollidersRemain;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        detectedColliders.Add(collision);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        detectedColliders.Remove(collision);
        if(detectedColliders.Count <= 0)
        {
            noCollidersRemain.Invoke();
        }
    }
  
}
