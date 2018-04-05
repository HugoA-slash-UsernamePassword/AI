using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SunnyLand
{
    public class PlayerController : MonoBehaviour
    {
        public float walkSpeed = 5f;
        public float crouchSpeed = 2f;
        public float speed = 5f;
        public int health = 100;
        public int damage = 50;
        public float hitForce = 4f;
        [Tooltip("Force applied to player when hit")]
        public float damageForce = 4f;
        public float maxVelocity;
        public float maxSlopeAngle = 45f;
        [Header("Grounding")]
        public float rayDistance = .5f;
        public bool isGrounded = false;
        public bool isOnSlope = false;
        [Header("Crouch")]
        public bool isCrouching = false;
        [Header("Jump")]
        public float jumpHeight = 2f;
        public int maxJumpCount = 2;
        public bool isJumping = false;

        private Vector3 groundNormal = Vector3.up;
        private int currentJump = 0;
        private float inputH, inputV;

        // References
        private SpriteRenderer rend;
        private Animator anim;
        private Rigidbody2D rigid;

        #region Unity Functions
        // Use this for initialization
        void Awake()
        {
            rend = GetComponent<SpriteRenderer>();
            anim = GetComponent<Animator>();
            rigid = GetComponent<Rigidbody2D>();

            speed = walkSpeed;
        }
        // Update is called once per frame
        void Update()
        {
            PerformMove();
            PerformJump();
        }
        void FixedUpdate()
        {
            DetectGround();
        }
        void OnDrawGizmos()
        {
            // Draw ground ray
            Ray groundRay = new Ray(transform.position, Vector3.down);
            Gizmos.DrawLine(groundRay.origin, groundRay.origin + groundRay.direction * rayDistance);
            // Draw Direction of movement
            Vector3 right = Vector3.Cross(groundNormal, Vector3.forward);
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position - right * 1f, transform.position + right * 1f);
        }
        #endregion

        #region Custom Functions
        public void Jump()
        {
            isJumping = true;
        }
        public void Crouch()
        {

        }
        public void UnCrouch()
        {

        }
        public void Move(float horizontal)
        {
            // If there is horizontal input
            if(horizontal != 0)
            {
                // Flip the sprite in the correct direction
                rend.flipX = horizontal < 0;
            }
            inputH = horizontal;
        }
        public void Hurt(int damage)
        {

        }

        private void PerformClimb()
        {

        }
        private void PerformMove()
        {
            Vector3 right = Vector3.Cross(groundNormal, Vector3.forward);
            rigid.AddForce(right * inputH * speed);

            LimitVelocity();
        }
        private void PerformJump()
        {
            if (isJumping)
            {
                if (currentJump < maxJumpCount - 1)
                {
                    currentJump++;
                    rigid.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
                }
                isJumping = false;
            }
        }
        private bool CheckGround(RaycastHit2D hit)
        {
            if (hit.collider != null && hit.collider.name != name && hit.collider.isTrigger == false)
                {
                // Reset jump
                currentJump = 0;
                // isGrounded is true
                isGrounded = true;
                // update ground normal
                groundNormal = hit.normal;

                // Calculate slope angle
                float slopeAngle = Vector3.Angle(Vector3.up, hit.normal);
                // Check if slope is within range of parameters
                if (Mathf.Abs(slopeAngle) > 0 &&
                   Mathf.Abs(slopeAngle) < maxSlopeAngle)
                {
                    // Is on slope
                    isOnSlope = true;
                }
                else
                {
                    // Is not on slope
                    isOnSlope = false;
                }
                // Check if I've reached the maximum slope angle
                if (Mathf.Abs(slopeAngle) >= maxSlopeAngle)
                {
                    // USE GRAVITY TO PUSH IT DOWN
                    rigid.AddForce(Physics2D.gravity);
                }

                return true;
            }
            return false;
        }
        private void CheckEnemy(RaycastHit2D hit)
        {

        }
        private void DetectClimbable()
        {

        }
        private void DetectGround()
        {
            // Create a ray going in the direction of down
            Ray groundRay = new Ray(transform.position, Vector3.down);
            // Get all the hit objects (perform RaycastAll)
            RaycastHit2D[] hits = Physics2D.RaycastAll(groundRay.origin, groundRay.direction, rayDistance);
            // Foreach hit in the list
            foreach (var hit in hits)
            {
                CheckEnemy(hit);
                if(Mathf.Abs(hit.normal.x) > 0.1f)
                {
                    rigid.gravityScale = 0.6f;
                }
                else
                {
                    rigid.gravityScale = 1;
                }
                if (CheckGround(hit))
                {
                    return;
                }
            }
        }
        private void LimitVelocity()
        {
            Vector3 vel = rigid.velocity;
            if(vel.magnitude >= maxVelocity)
            {
                vel = vel.normalized * maxVelocity;
            }
            rigid.velocity = vel;
        }
        private void StopClimbing()
        {

        }
        private void EnablePhysics()
        {

        }
        private void DisablePhysics()
        {

        }

        #endregion
    }
}