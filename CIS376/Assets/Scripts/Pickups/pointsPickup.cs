using Assets.Scripts.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointsPickup : Pickup
{
    public int pointGet = 100;
    public AudioSource pickupSource;
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
            CharacterEvents.characterPointGet.Invoke(gameObject,pointGet);
            AudioSource.PlayClipAtPoint(pickupSource.clip, gameObject.transform.position, pickupSource.volume);
            Destroy(gameObject);
        }
    }
}
