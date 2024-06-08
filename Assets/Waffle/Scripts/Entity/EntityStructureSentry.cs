using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Structure
{
    public class EntityStructureSentry : Entity
    {
        [SerializeField] Animator animator;
        [SerializeField] float _range;
        [SerializeField] Entity target;

        private void FixedUpdate()
        {
            Collider[] col = Physics.OverlapSphere(this.transform.position, _range);
            foreach(Collider c in col)
            {
                if(c.TryGetComponent<Enemy.EntityEnemy>(out Enemy.EntityEnemy Target))
                {
                    target = Target;
                    break;
                }
            }

            if (target != null)
            { 

            }
        }
    }
}
