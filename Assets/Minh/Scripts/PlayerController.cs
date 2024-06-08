
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
            float horizontalInput;
            float verticalInput;
            public bool canMove = true;
            
            private Rigidbody rb;
    
            void Start()
            {
                rb = GetComponent<Rigidbody>();
            }
    
            void Update()
            {
                // Get input for movement and rotation
                horizontalInput = Input.GetAxis("Horizontal");
                verticalInput = Input.GetAxis("Vertical");
            }
            void FixedUpdate()
            {
                if(!canMove)
                    return;
                // Calculate desired movement direction
                Vector3 movement = new Vector3(horizontalInput, 0, verticalInput).normalized;
    
                if (movement != Vector3.zero)
                {
                    float angle = Vector3.Angle(transform.forward, movement);
                }
    
                // Apply movement
                rb.velocity = movement * speed + new Vector3(0, rb.velocity.y, 0);
    
                // Rotate towards movement direction
                if (movement != Vector3.zero)
                {
                    Quaternion targetRotation = Quaternion.LookRotation(movement);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                }
            }

            public void DeadStop()
            {
                rb.velocity = new Vector3(0, rb.velocity.y, 0);
            }
            
        }
}
