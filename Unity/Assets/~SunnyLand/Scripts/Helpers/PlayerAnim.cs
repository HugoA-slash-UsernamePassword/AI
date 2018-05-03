using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SunnyLand
{
    [RequireComponent(typeof(PlayerController))]
    public class PlayerAnim : MonoBehaviour
    {
        private PlayerController player;
        // Use this for initialization
        void Start()
        {
            player = GetComponent<PlayerController>();
            player.onJump += OnJump;
            player.onMove += OnMove;
            player.onClimb += OnClimb;
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnJump()
        {

        }
        void OnMove(float input)
        {

        }
        void OnClimb(float input)
        {

        }
    }
}