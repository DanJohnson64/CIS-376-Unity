using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource introSource, loopSource, gameOverSource, winSource;
    // Start is called before the first frame update
    void Start()
    {
        introSource.Play();
        loopSource.PlayScheduled(AudioSettings.dspTime + introSource.clip.length + 0.03);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onGameOver()
    {
        loopSource.Stop();
        introSource.Stop();
        //gameOverSource.Play();

    }
}
