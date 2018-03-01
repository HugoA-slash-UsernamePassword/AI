using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoneHome
{
    public class Death : MonoBehaviour
    {
        void Died()
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "KillZone" ||
                other.tag == "Enemy")
            {
                Died();
            }
        }
    }
}
