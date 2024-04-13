using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointsPickup : Pickup
{
    public int pointGet = 100;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If an entity enters this collider and has a damageable component 
        PointManager pointManager= collision.GetComponent<PointManager>();

        if (pointManager)
        {
            pointManager.getPoints(pointGet);
            
            Destroy(gameObject);
        }
    }
}
