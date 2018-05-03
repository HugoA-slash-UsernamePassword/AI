using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GoneHome
{
    public class Death : MonoBehaviour
    {
        public UnityEvent onDeath;

        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "KillZone" ||
                other.tag == "Enemy")
            {
                //Died();
                onDeath.Invoke();
            }
        }
    }
}
//void Died()
//{
//    //Application.LoadLevel(Application.loadedLevel);
//}