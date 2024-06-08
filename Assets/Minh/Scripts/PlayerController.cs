
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Player
{
        public class PlayerController : MonoBehaviour
        {
            public float speed = 5f;
            public float rotationSpeed = 720f; // Degrees per second
            float horizontalInputMov;
            float verticalInputMov;
            
            float horizontalInputTurn;
            float verticalInputTurn;
            public bool canMove = true;
            
            private Rigidbody rb;

            private Vector3 movement;
            private Vector3 turn;
    
            void Start()
            {
                rb = GetComponent<Rigidbody>();
            }
    
            void Update()
            {
                // Get input for movement and rotation
                horizontalInputMov = Input.GetAxisRaw("Horizontal");
                verticalInputMov = Input.GetAxisRaw("Vertical");
                
                horizontalInputTurn = Input.GetAxis("Horizontal");
                verticalInputTurn = Input.GetAxis("Vertical");                
                
            }
            void FixedUpdate()
            {
                if(!canMove)
                    return;
                
                movement = new Vector3(horizontalInputMov, 0, verticalInputMov).normalized;
                turn = new Vector3(horizontalInputTurn, 0, verticalInputTurn).normalized;
                
                // Calculate desired movement direction
                if (turn != Vector3.zero)
                {
                    float angle = Vector3.Angle(transform.forward, turn);
                    Quaternion targetRotation = Quaternion.LookRotation(turn);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                }
                else
                {
                    rb.velocity = new Vector3(0, rb.velocity.y, 0);
                }
    
                // Apply movement
                rb.velocity = movement * speed + new Vector3(0, rb.velocity.y, 0);
            }

            public void DeadStop()
            {
                rb.velocity = new Vector3(0, rb.velocity.y, 0);
            }

            public bool GetMoving()
            {
                if(movement == Vector3.zero)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            
        }
}
