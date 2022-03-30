using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Assets.Scripts
{
    public class PlayerHealth : MonoBehaviour
    {
        public Slider slider;
        public int maxHealth = 100;
        public int currentHealth;
        public TMP_Text healthText;
        
        public Canvas gameOver;

        private void Start()
        {
            currentHealth = maxHealth;
            setMaxHealth(maxHealth);
        }
        public void setMaxHealth(int Health)
        {
            slider.maxValue = Health;
            slider.value = Health;
        }
        
        public void setHealth(int health)
        {
            slider.value = health;
        }

        public void takeDamage(int damage)
        {
            currentHealth -= damage;
            setHealth(currentHealth);
            healthText.text = "Health : " + currentHealth.ToString();

            if(currentHealth <= 0f)
            {
                Die();
            }
        }

        public void Die()
        {
            Destroy(gameObject);
            gameOver.enabled = true;
        }
    }
}