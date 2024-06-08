using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Structure
{
    public class SentryBehaviour : MonoBehaviour
    {
        EntityStructureSentry Base;
        [SerializeField] Transform CharacterParent;
        [SerializeField] Animator animator;
        [SerializeField] Weapon.WeaponObject weapon;
        Entity target;
        void Start()
        {
            Base = this.GetComponent<EntityStructureSentry>();
        }

        private void FixedUpdate()
        {
            BehaviourHandler();
            FindTarget();
            if(target != null)
            {
                if (weapon.canAttack)
                {
                    Attack();
                }
            }
        }

        void FindTarget()
        {
            target = null;
            Collider[] col = Physics.OverlapSphere(this.transform.position, Base.Range);
            foreach (Collider c in col)
            {
                if (c.TryGetComponent<Enemy.EntityEnemy>(out Enemy.EntityEnemy Target))
                {
                    target = Target;
                    break;
                }
            }
        }

        void Attack()
        {
            if (Vector3.Distance(this.transform.position, target.transform.position) <= Base.Range)
            {
                weapon.StartCoroutine(weapon.Attack(target));
            }
        }

        void BehaviourHandler()
        {
            if (weapon.attacking)
            {
                animator.SetBool("attacking", true);
            }
            else
            {
                animator.SetBool("attacking", false);
            }

            if(target != null)
            {
                Debug.Log(target.name);
                Vector3 safeguard = target.transform.position;
                safeguard.Scale(new Vector3(0, -1, -1));

                CharacterParent.transform.LookAt(target.transform.position);
            }
            else
            {
                CharacterParent.transform.rotation = Quaternion.Euler(Vector3.zero);
            }
        }
    }
}
