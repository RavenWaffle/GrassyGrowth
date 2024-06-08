using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EntityEnemy : Entity
    {
        [SerializeField] NavMeshAgent _agent;
        public NavMeshAgent Agent => _agent;
        [SerializeField] float _speed;
        public float Speed => _speed;
        [SerializeField] float _range;
        public float Range => _range;
    }
}
