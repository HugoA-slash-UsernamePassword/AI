using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class DestroyOnTrigger : MonoBehaviour
    {
        public string nameContains;

        void OnTriggerEnter(Collider col)
        {
            // Detect 'nameContains' in name string
            if (col.name.Contains(nameContains))
            {
                // Kill off GameObject
                Destroy(col.gameObject);
            }
        }
    }
}