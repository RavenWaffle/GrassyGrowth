using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyBehaviour : MonoBehaviour
    {
        EntityEnemy Base;
        [SerializeField] Animator animator;
        [SerializeField] Weapon.WeaponObject weapon;
        [SerializeField] Transform target;
        [SerializeField] float _playerDetectionRange;


        float startAngularSpeed;
        private void Start()
        {
            Base = this.GetComponent<EntityEnemy>();
            Base.Agent.speed = Base.Speed;
            Base.Agent.stoppingDistance = Base.Range;
            startAngularSpeed = Base.Agent.angularSpeed;
        }

        private void FixedUpdate()
        {
            if(Vector3.Distance(this.transform.position, target.position) > Base.Range)
            {
                Move(target.position);
            }
            else if(weapon.canAttack)
            {
                Attack();
            }
            BehaviourHandler();
        }

        public void Move(Vector3 destination)
        {
            Base.Agent.destination = destination;
        }

        public void SetTarget(Transform Target)
        {
            target = Target;
        }

        public bool GetPlayer()
        {
            Collider[] col = Physics.OverlapSphere(this.transform.position, _playerDetectionRange);
            foreach(Collider c in col)
            {
                if(c.CompareTag("Player"))
                {
                    return true;
                }
            }
            return false;
        }

        void Attack()
        {
            if(Vector3.Distance(this.transform.position, target.position) <= Base.Range)
            {
                Base.Agent.velocity = Vector3.zero;
                if (target.TryGetComponent<Entity>(out Entity targetEntity))
                {
                    weapon.StartCoroutine(weapon.Attack(targetEntity));
                }
            }
        }

        void BehaviourHandler()
        {
            if(weapon.attacking)
            {
                Base.Agent.angularSpeed = 0;
                Base.Agent.speed = 0;
                animator.SetBool("attacking", true);
            }
            else
            {
                Base.Agent.angularSpeed = startAngularSpeed;
                Base.Agent.speed = Base.Speed;
                animator.SetBool("attacking", false);
            }

            if(Base.Agent.velocity.magnitude != 0)
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
