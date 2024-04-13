using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsText : MonoBehaviour
{
    //Game Component objects 
    RectTransform textTransform;
    TextMeshProUGUI textMeshPro;

    //Class variables
    public Vector3 moveSpeed = Vector3.up;
    public float timeToFade = 0.5f;
    private float timeElapsed = 0f;
    private Color startColor;
    private float fadeAlpha;
    

    private void Awake()
    {
       textTransform= GetComponent<RectTransform>();
       textMeshPro = GetComponent<TextMeshProUGUI>();
       startColor = textMeshPro.color;
    }

    private void Update()
    {
        textTransform.position += moveSpeed * Time.deltaTime;
        timeElapsed += Time.deltaTime;

        if(timeElapsed < timeToFade)
        {
            fadeAlpha = startColor.a * 1 -(timeElapsed / timeToFade);
            textMeshPro.color = new Color(startColor.r, startColor.g, startColor.b, fadeAlpha);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
