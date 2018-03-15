using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GoneHome
{
    public class Goal : MonoBehaviour
    {
        public UnityEvent onGoal;
        public int longth;

        private void OnTriggerEnter(Collider other)
        {
            if (other.name.Contains("Player") && longth <= 0)
            {
                onGoal.Invoke();
            }
        }
        public void minus()
        {
            longth--;
        }
    }
}