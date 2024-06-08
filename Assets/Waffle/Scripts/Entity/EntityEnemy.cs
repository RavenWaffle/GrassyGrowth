using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EntityEnemy : Entity
    {
        [SerializeField] EnemyCommander _commander;
        public EnemyCommander Commander => _commander;

        [SerializeField] NavMeshAgent _agent;
        public NavMeshAgent Agent => _agent;
        [SerializeField] float _speed;
        public float Speed => _speed;
        [SerializeField] float _range;
        public float Range => _range;

        private void Start()
        {
            _commander = GameObject.FindGameObjectWithTag("Commander").GetComponent<EnemyCommander>();
        }


        void Update()
        {
            Die();
        }

        protected override void Die()
        {
            if(Health <= 0)
            {
                TilesManager tilesManager = GameObject.FindGameObjectWithTag("TileManager").GetComponent<TilesManager>();
                tilesManager.enemiesToKill--;
                Destroy(this.gameObject);
            }
        }
    }
}
