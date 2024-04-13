using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    Damageable playerDamageable;
    public UnityEngine.UI.Slider healthSlider;

    private void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerDamageable = player.GetComponent<Damageable>();
    }
    // Start is called before the first frame update
    void Start()
    {       
        healthSlider.value = calculateSliderPercentage(playerDamageable.Health, playerDamageable.MaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private float calculateSliderPercentage(float currentHealth, float maxHealth)
    {
        return currentHealth / maxHealth;
    }

    private void OnEnable()
    {
        playerDamageable.healthChanged.AddListener(OnPlayerHealthChanged);
    }

    private void OnDisable()
    {
        playerDamageable.healthChanged.RemoveListener(OnPlayerHealthChanged);
    }


    private void OnPlayerHealthChanged(int newHealth, int MaxHealth)
    {
        healthSlider.value = calculateSliderPercentage(newHealth, MaxHealth);

    }

}
