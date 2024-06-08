using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerBehaviour : MonoBehaviour
    {
        [SerializeField] Animator animator;
        [SerializeField] Player.PlayerController pc;
        [SerializeField] PlayerResource pr;

        // Update is called once per frame
        void Update()
        {
            if(pr.spraying)
            {
                animator.SetBool("spraying", true);
            }
            else
            {
                animator.SetBool("spraying", false);
            }

            if (pc.GetMoving())
            {
                animator.SetBool("moving", true);
            }
            else
            {
                animator.SetBool("moving", false);
            }
        }
    }
}
