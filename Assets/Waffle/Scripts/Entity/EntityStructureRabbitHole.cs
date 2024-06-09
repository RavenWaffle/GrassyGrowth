using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace Structure
{
    public class EntityStructureRabbitHole : Entity
    {
        private GameObject player;
        [SerializeField] private GameObject playerPrefab;
        private bool respawned;
        public float timeToSpawn;

        public GameObject loseScreen;
        public GameObject canvas;

        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        private void Update()
        {
            if(player.GetComponent<Entity>().Health <= 0)
            StartCoroutine(PlayerRespawn());
        }

        IEnumerator PlayerRespawn()
        {
            yield return new WaitForSeconds(timeToSpawn);
            player.transform.position = this.transform.position + new Vector3(0, 0, 3);
            player.SetActive(true);
            player.GetComponent<EntityPlayer>().SetHealth(100);
            player.GetComponent<EntityPlayer>().enabled = true;
        }

        protected override void Die()
        {
            if (health <= 0)
            {
                canvas.SetActive(false);
                loseScreen.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
