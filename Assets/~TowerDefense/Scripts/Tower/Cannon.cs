using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Cannon : Tower
    {
        public Transform barrel;
        public float lineDelay = 2f;

        private LineRenderer line;

        void Awake()
        {
            line = GetComponent<LineRenderer>();
        }

        public override void Aim(Enemy e)
        {
            // Line from center point
            line.SetPosition(0, transform.position);
            // Line to barrel
            line.SetPosition(1, barrel.position);
            // Line to enemy
            line.SetPosition(2, e.transform.position);

            Vector3 targetPos = e.transform.position;
            Vector3 barrelPos = barrel.position;
            Vector3 fireDirection = targetPos - barrelPos;
            barrel.rotation = Quaternion.LookRotation(fireDirection);
        }
        public override void Attack(Enemy e)
        {
            e.DealDamage(damage);
        }
    }
}