using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements.Experimental;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject timer;
    public GameObject musicPlayer;
    public TMP_Text gameOverScoreText;
    public TMP_Text gameOverText;

    private Timer _timer;
    private MusicPlayer _musicPlayer;
    


    void Awake()
    {
        _timer = timer.GetComponent<Timer>();
        _musicPlayer = musicPlayer.GetComponent<MusicPlayer>();
        
    }   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameOver(int score)
    {
        _musicPlayer.onGameOver();
        gameOverScoreText.text = score.ToString();
        gameOverUI.SetActive(true);
        
        
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    
    public void endStage(int points)
    {
        gameOverScoreText.text = calculateFinalScore(points).ToString(); 
        gameOverText.text = "Stage Cleared";
        gameOverUI.SetActive(true);            
    }

    private int calculateFinalScore(int points)
    {
        float score = points;
        if(_timer.seconds <= 90)
        {
            score = score * 1.8f;            
        }
        if(_timer.seconds > 90 && _timer.seconds < 180)
        {
            score = score * 1.2f;
        }
        return (int)Mathf.Floor(score);
    }
}
