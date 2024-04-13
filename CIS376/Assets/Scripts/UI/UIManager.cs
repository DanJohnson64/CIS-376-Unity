using Assets.Scripts.Events;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.Rendering;

public class UIManager : MonoBehaviour
{
    public GameObject pointsTextPrefab;
    public GameObject healthTextPrefab;
    public Canvas gameCanvas;


    private void Awake()
    {
        gameCanvas = FindObjectOfType<Canvas>();
    }

    private void OnEnable()
    {
        CharacterEvents.characterDamaged += characterTookDamage;
        CharacterEvents.characterHealed += characterHealed;
    }

    private void OnDisable()
    {
        CharacterEvents.characterDamaged -= characterTookDamage;
        CharacterEvents.characterHealed -= characterHealed;
    }

    //spawns points text at character location displaying the amount of points gained
    public void pointsGained(GameObject character, int pointsGained)
    {
        Vector3 spawnPosition = Camera.main.WorldToScreenPoint(character.transform.position);
        TMP_Text tmpText = Instantiate(pointsTextPrefab, spawnPosition, Quaternion.identity, gameCanvas.transform).GetComponent<TMP_Text>();
        tmpText.text = pointsGained.ToString();
    }

    public void characterTookDamage(GameObject character, int damageTaken)
    {
        //TODO decrease character health UI
    }

    public void characterHealed(GameObject character, int healthGained)
    {
        Vector3 spawnPosition = Camera.main.WorldToScreenPoint(character.transform.position);
        TMP_Text tmpText = Instantiate(healthTextPrefab, spawnPosition, Quaternion.identity, gameCanvas.transform).GetComponent<TMP_Text>();
        tmpText.text = healthGained.ToString();
        //TODO increase character health UI
    }
}
