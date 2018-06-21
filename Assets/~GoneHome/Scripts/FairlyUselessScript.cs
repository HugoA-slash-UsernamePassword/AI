using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoneHome
{
    public class FairlyUselessScript : MonoBehaviour
    {
        void Reset()
        {
            GetComponent<BoxCollider>().enabled = true;
            GetComponent<MeshRenderer>().enabled = true;
        }
    }
}