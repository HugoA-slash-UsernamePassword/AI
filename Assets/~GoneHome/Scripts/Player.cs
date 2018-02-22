using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoneHome
{
    [RequireComponent(typeof(Rigidbody))]

    public class Player : MonoBehaviour
    {
        public float movementSpeed = 20f;

        private Rigidbody rigid;
        private Transform cam;
        void Start()
        {
            rigid = GetComponent<Rigidbody>();

            cam = Camera.main.transform;
        }

        void Update()
        {
            Movement();
        }

        void Movement()
        {
            float inputH = Input.GetAxis("Horizontal");
            float inputV = Input.GetAxis("Vertical");

            Vector3 inputDir = new Vector3(inputH, 0, inputV);

            inputDir = Quaternion.AngleAxis(cam.eulerAngles.y, Vector3.up) * inputDir;

            // Moves the position of the rigidbody without 
            // effecting gravity
            Vector3 position = transform.position;
            position += inputDir * movementSpeed * Time.deltaTime;
            rigid.MovePosition(position);
        }
    }
}
