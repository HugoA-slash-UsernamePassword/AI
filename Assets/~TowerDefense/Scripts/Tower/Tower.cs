using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Tower : MonoBehaviour
    {
        public float damage = 10f;
        public float attackDelay = 1f;

        protected Enemy currentEnemy;

        private float attackTimer = 0f;

        public virtual void Aim(Enemy e) { }
        public virtual void Attack(Enemy e) { }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        protected virtual void Update()
        {
            attackTimer -= Time.deltaTime;
            if (currentEnemy)
            {
                Aim(currentEnemy);
                if (attackTimer < 0)
                {
                    Attack(currentEnemy);
                    attackTimer = attackDelay;
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null &&
                currentEnemy == null)
            {
                currentEnemy = enemy;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null &&
                currentEnemy == enemy)
            {
                currentEnemy = null;
            }
        }
    }
}