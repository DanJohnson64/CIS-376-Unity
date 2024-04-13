using Assets.Scripts.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PointManager : MonoBehaviour
{

    public int points;
    public UnityEvent<int> playerGetPoints;
    

    public void getPoints(int pointAmount)
    {
        points += pointAmount;
        playerGetPoints?.Invoke(pointAmount);  
    }
 
}
