using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    public Slider m_Slider;
    public Image m_FillImage;
    public Color m_FullHealthColor = Color.green;
    public Color m_ZeroHealthColor = Color.red;
    public Text healthNumberText;
    private float maxHealth;
    private float currentHealth;
    private float minHealth = 0f;
    public PlayerController playerScript;

    // Runs when the scene starts
    private void Start()
    {
        playerScript = GetComponent<PlayerController>();    // Get the PlayerController script component on this object
        maxHealth = playerScript.getPlayerHealth();     // Get the player's maximum health from PlayerController
        currentHealth = playerScript.getPlayerHealth();     // Get the player's current health from PlayerController
        healthNumberText.text = healthNumberText.text + maxHealth + " / " + maxHealth;      // Set the content of the Text object to "100 / 100"
        setMaxHealth();     // Calls setMaxHealth(); function
        setHealth();        // Calls setHealth(); function
        setHealthUI();      // Calls setHealthUI(); function
    }

    // Runs every frame
    private void Update()
    {
        // Only runs when the current health does not equal to the minimum player health, 0
        if(currentHealth != minHealth)
        {
            currentHealth = playerScript.getPlayerHealth();     // Get the player's current health value from PlayerController
            healthNumberText.text = "";     // Clear the content of the Text object
            healthNumberText.text = healthNumberText.text + currentHealth + " / " + maxHealth;       // Set the content of the Text object to " currentHealthValue / 100"
            setHealth();       // Calls setHealth(); function
            setHealthUI();      // Calls setHealthUI(); function
        }    
    }

    // Set the Slider component's properties based on the health values
    private void setMaxHealth()
    {
        m_Slider.maxValue = maxHealth;      // Change the slider's maximium value to the player's maximum health
        m_Slider.value = currentHealth;     // Change the slider's current value to the player's current health
        m_Slider.minValue = minHealth;      // Change the slider's minimum value to the player's minimum health
    }

    // Update the health value
    private void setHealth()
    {
        m_Slider.value = currentHealth;      // Change the slider's current value to the player's current health
    }

    // Update the health bar UI 
    private void setHealthUI()
    {
        m_Slider.value = currentHealth;     // Change the slider's current value to the player's current health

        m_FillImage.color = Color.Lerp(m_ZeroHealthColor, m_FullHealthColor, currentHealth / maxHealth);       // Changes the health bar colour depending on the value of the current health, from Green to Red
    }
}

