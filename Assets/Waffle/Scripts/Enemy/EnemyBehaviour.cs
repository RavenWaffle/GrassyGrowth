using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyBehaviour : MonoBehaviour
    {
        EntityEnemy Base;
        [SerializeField] Weapon.WeaponObject weapon;
        [SerializeField] Transform target;
        [SerializeField] float _playerDetectionRange;
        private void Start()
        {
            Base = this.GetComponent<EntityEnemy>();
            Base.Agent.speed = Base.Speed;
            Base.Agent.stoppingDistance = Base.Range;
        }

        private void FixedUpdate()
        {
            if(Vector3.Distance(this.transform.position, target.position) > Base.Range)
            {
                Move(target.position);
            }
            else
            {
                Attack();
            }
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
                if(target.TryGetComponent<Entity>(out Entity targetEntity))
                {
                    weapon.StartCoroutine(weapon.Attack(targetEntity));
                }
            }
        }
    }
}
