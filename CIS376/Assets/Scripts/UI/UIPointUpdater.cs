using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIPointUpdater : MonoBehaviour
{
    PointManager playerPoints;
    public TMP_Text pointText;

    private void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerPoints = player.GetComponent<PointManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        pointText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {

    }    

    private void OnEnable()
    {
        playerPoints.playerGetPoints.AddListener(OnPointGet);
    }

    private void OnDisable()
    {
        playerPoints.playerGetPoints.RemoveListener(OnPointGet);
    }


    private void OnPointGet(int points)
    {
        pointText.text = playerPoints.points.ToString();

    }
}
