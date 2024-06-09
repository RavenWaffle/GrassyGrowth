using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemy
{
    public class EnemyBehaviour : MonoBehaviour
    {
        EntityEnemy Base;
        [SerializeField] Animator animator;
        [SerializeField] Weapon.WeaponObject weapon;
        public Entity target;
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
            TargetManager();
            BehaviourHandler();

            if (target == null)
                return;

            if(Vector3.Distance(this.transform.position, target.gameObject.transform.position) > Base.Range)
            {
                Move(target.gameObject.transform.position);
            }
            else if(weapon.canAttack)
            {
                Attack();
            }
        }

        public void Move(Vector3 destination)
        {
            Base.Agent.destination = destination;
        }

        public void SetTarget(Entity Target)
        {
            target = Target;
        }

        void Attack()
        {
            if(Vector3.Distance(this.transform.position, target.gameObject.transform.position) <= Base.Range)
            {
                transform.LookAt(target.gameObject.transform.position);
                Base.Agent.velocity = Vector3.zero;
                if (target.TryGetComponent<Entity>(out Entity targetEntity))
                {
                    weapon.StartCoroutine(weapon.Attack(targetEntity));
                }
            }
        }

        void TargetManager()
        {
            if (target != null)
            {
                if (!target.enabled)
                {
                    target = null;
                }
            }
            
            if(target == null)
            {
                animator.SetBool("attacking", false);
                Base.Commander.GiveOrder(ref target, this.transform.position);
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
