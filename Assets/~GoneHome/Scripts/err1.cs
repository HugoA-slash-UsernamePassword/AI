using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoneHome
{
    public class err1 : MonoBehaviour
    {
        private int counter = 0;
        private Vector3 origin;
        public float change = 0;
        public float spd = 4;
        public int xSin = 0;
        public int ySin = 0;
        public int zSin = 0;
        // Use this for initialization
        void Start()
        {
            change *= Mathf.PI/2;
            origin = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = new Vector3(origin.x + (Mathf.Sin(Time.time + change) * spd) * xSin, origin.y + (Mathf.Sin(Time.time + change) * spd) * ySin, origin.z + (Mathf.Sin(Time.time + change) * spd) * zSin);
            counter++;
            if (counter > 6)
            {

                counter = 0;
            }
        }
    }
}