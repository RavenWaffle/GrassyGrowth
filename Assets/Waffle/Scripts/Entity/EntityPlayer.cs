using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Player
{
    public class EntityPlayer : Entity
    {
        void Update()
        {
            Die();
        }

        protected override void Die()
        {
            if(Health <= 0)
            {
                this.gameObject.SetActive(false);
                this.enabled = false;
            }
        }
    }
}
