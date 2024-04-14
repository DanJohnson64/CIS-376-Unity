using Assets.Scripts.Events;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    public GameObject pointsTextPrefab;
    public GameObject totalPointsPrefab;
    public GameObject healthTextPrefab;
    public Canvas gameCanvas;
    private int totalPoints;


    private void Awake()
    {
        gameCanvas = FindObjectOfType<Canvas>();
    }

    private void OnEnable()
    {        
        CharacterEvents.characterHealed += characterHealed;
        CharacterEvents.characterPointGet += pointsGained;
        CharacterEvents.enemyKilled += enemyKilledPoints; 
        
    }

    private void OnDisable()
    {       
        CharacterEvents.characterHealed -= characterHealed;
        CharacterEvents.characterPointGet -= pointsGained;
        CharacterEvents.enemyKilled += enemyKilledPoints;
    }

    //spawns points text at character location displaying the amount of points gained
    public void pointsGained(GameObject character, int pointsGained)
    {
        Vector3 spawnPosition = Camera.main.WorldToScreenPoint(character.transform.position);
        TMP_Text tmpText = Instantiate(pointsTextPrefab, spawnPosition, Quaternion.identity, gameCanvas.transform).GetComponent<TMP_Text>();   
        totalPoints += pointsGained;
        tmpText.text = pointsGained.ToString();

    }

    public void enemyKilledPoints(GameObject character, int pointsKilled)
    {
        Vector3 spawnPosition = Camera.main.WorldToScreenPoint(character.transform.position);
        TMP_Text tmpText = Instantiate(pointsTextPrefab, spawnPosition, Quaternion.identity, gameCanvas.transform).GetComponent<TMP_Text>();
        totalPoints += pointsKilled;
        tmpText.text = pointsKilled.ToString();
    }

    

    public void characterHealed(GameObject character, int healthGained)
    {
        Vector3 spawnPosition = Camera.main.WorldToScreenPoint(character.transform.position);
        TMP_Text tmpText = Instantiate(healthTextPrefab, spawnPosition, Quaternion.identity, gameCanvas.transform).GetComponent<TMP_Text>();
        //tmpText.text = healthGained.ToString();
        //TODO increase character health UI
    }

    public void OnExit(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            #if (UNITY_EDITOR || DEVELOPMENT_BUILD)
                Debug.Log(this.name + " : " + this.GetType() + " : " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            #endif

            #if (UNITY_EDITOR)
                UnityEditor.EditorApplication.isPlaying= false;
            #elif (UNITY_STANDALONE)
                        Application.Quit();
            #elif (UNITY_WEBGL)
                        SceneManager.LoadScene("QuitScene");
            #endif

        }
    }
}
