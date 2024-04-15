using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Events;

public class EndStageGem : MonoBehaviour
{
  public GameManager gameManager;

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
            gameManager.endStage(pointManager.points);
            AudioSource.PlayClipAtPoint(pickupSource.clip, gameObject.transform.position, pickupSource.volume);
            
            Destroy(gameObject);
        }
    }
}
