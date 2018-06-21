using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{
    public class Enemy : MonoBehaviour
    {
        public float maxHealth = 100;
        [Header("UI")]
        public GameObject healthBarUI;
        public Vector2 healthBarOffset = new Vector2(0, 5f);

        private Slider healthSlider;
        private float curHealth = 100f;

        void Start()
        {
            curHealth = maxHealth;
        }

        void OnDestroy()
        {
            // If there is a health slider attached to the enemy
            if (healthSlider)
            {
                // Destroy the health bar UI
                Destroy(healthSlider.gameObject);
            }
        }

        void Update()
        {
            if (healthSlider)
            {
                healthSlider.transform.position = GetHealthBarPos();
            }
        }

        Vector3 GetHealthBarPos()
        {
            Camera cam = Camera.main;
            Vector3 position = cam.WorldToScreenPoint(transform.position);
            return position + (Vector3)healthBarOffset;
        }

        public void SpawnHealthBar(Transform parent)
        {
            GameObject clone = Instantiate(healthBarUI, GetHealthBarPos(), Quaternion.identity, parent);
            healthSlider = clone.GetComponent<Slider>();
        }
        /// <summary>
        /// Deals damage to the Droid
        /// </summary>
        /// <param name="damage">Damage to deal</param>
        public void DealDamage(float damage)
        {
            // Deal damage to droid
            curHealth -= damage;
            if (healthSlider)
            {
                // Convert health to a 0-1 value (health / maxHealth)
                healthSlider.value = curHealth / maxHealth;
            }
            // If there is no health
            if (curHealth <= 0)
            {
                // Kill off GameObject
                Destroy(gameObject);
            }
        }
    }
}