using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

namespace TowerDefense
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class AIAgent : MonoBehaviour
    {
        public Transform target;

        private NavMeshAgent nav;

        void Awake()
        {
            // Reference the nav mesh component
            nav = GetComponent<NavMeshAgent>();
        }

        void Update()
        {
            // If a target has been set
            if (target != null)
            {
                // Navigate to the target 
                nav.SetDestination(target.position);
            }
        }
    }
}