using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoneHome
{
    public class Death : MonoBehaviour
    {
        void Died()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "DeathZone" ||
                other.name == "Enemy")
            {
                Died();
            }
        }
    }
}
