using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Droid : MonoBehaviour
    {
        public float health = 100;
        /// <summary>
        /// Deals damage to the Droid
        /// </summary>
        /// <param name="damage">Damage to deal</param>
        public void DealDamage(float damage)
        {
            // Deal damage to droid
            health -= damage;
            // If there is no health
            if (health <= 0)
            {
                // Kill off GameObject
                Destroy(gameObject);
            }
        }
    }
}