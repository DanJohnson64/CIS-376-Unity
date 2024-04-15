
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{

    void Awake()
    {
        gameObject.SetActive(false);
    }
    
    void OnEnable()
    {
        
    }

    void OnDisable()
    {
        
    }

    void gameOverSequence()
    {
        gameObject.SetActive(true);
    }
    
}
