using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    
    private float timer = 0f;
    public int seconds;

    private void Awake()
    {
        timerText = gameObject.GetComponent<TMP_Text>();
    }
    void Update()
    {
        // Increment the timer
        timer += Time.deltaTime;

        // Convert the timer value to minutes and seconds
        int minutes = Mathf.FloorToInt(timer / 60);
        seconds = Mathf.FloorToInt(timer % 60);
        

        // Update the text to display the timer
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
