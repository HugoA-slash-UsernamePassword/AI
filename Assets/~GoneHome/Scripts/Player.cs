using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GoneHome
{
    [RequireComponent(typeof(Rigidbody))]

    public class Player : MonoBehaviour
    {
        public float movementSpeed = 20f;
        public float maxVelocity = 5f;
        public GameObject deathParticles;
        private Vector3 check;
        private Rigidbody rigid;
        private Transform cam;
        private Vector3 spawnPoint;
        public UnityEvent kill;
        void Start()
        {
            rigid = GetComponent<Rigidbody>();

            cam = Camera.main.transform;
            check = transform.position;
            spawnPoint = transform.position;
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

            rigid.AddForce(inputDir * movementSpeed);
            Vector3 vel = rigid.velocity;
            if (vel.magnitude > maxVelocity)
            {
                vel = vel.normalized * maxVelocity;
            }
            rigid.velocity = vel;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.name.Contains("Goal"))
            {
                other.GetComponent<BoxCollider>().enabled = false;
                other.GetComponent<MeshRenderer>().enabled = false;
                kill.Invoke();
            }
        }
        public void Reset()
        {
            Instantiate(deathParticles, transform.position, transform.rotation);
            rigid.velocity = Vector3.zero;
            transform.position = spawnPoint;
        }
    }
}
