using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    Collider2D _collider;
    public List<Collider2D> detectedColliders = new List<Collider2D>();

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        detectedColliders.Add(_collider);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        detectedColliders.Remove(_collider);
    }
  
}
