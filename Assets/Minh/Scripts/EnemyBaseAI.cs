#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AI;
using UnityEngine.Events;

    public class EnemyBaseAI : MonoBehaviour
    {
        [System.Serializable]
        public class Events
        {
            public UnityEvent OnSpawn, OnShoot, OnDamaged, OnDeath;
        }

        [Tooltip("Name of the enemy. This will appear on the killfeed"), SerializeField]
        public string _name;

        public float health;

        [Tooltip("initial enemy health "), SerializeField]
        public float maxHealth;


        [Tooltip("display enemy status via UI"), SerializeField]
        protected Slider healthSlider;

        [Tooltip(
             "If true, it will display the UI with the shield and health sliders, disabling this will disable pop ups."),
         SerializeField]
        public bool showUI;

        [Tooltip(
             "Add a pop up showing the damage that has been dealt. Recommendation: use the already made pop up included in this package. "),
         SerializeField]
        private GameObject damagePopUp;

        [Tooltip("Colour for the specific status to be displayed in the slider"), SerializeField]
        private Color healthColor;
        

        public Events events;

        public Entity entity;


        // Start is called before the first frame update"
        public virtual void Start()
        {

            entity = this.gameObject.GetComponent<Entity>();
            // Status initial settings
            maxHealth = entity.Health;
            health = maxHealth;

            // Spawn
            events.OnSpawn.Invoke();

            // UI 
            // Determine max values
            if (healthSlider != null) healthSlider.maxValue = maxHealth;
            if (!showUI) // Destroy the enemy UI if we do not want to display it
            {
                Destroy(healthSlider);
            }

        }

        // Update is called once per frame
        public virtual void Update()
        {
            health = entity.Health;
            //Handle UI 
            if (healthSlider != null) healthSlider.value = Mathf.Lerp(healthSlider.value, health, Time.deltaTime * 6);

            // Manage health
            if (health <= 0) Die();
        }

        /// <summary>
        /// Since it is IDamageable, it can take damage, if a shot is landed, damage the enemy
        /// </summary>
        public virtual void Damage(float _damage)
        {
                health -= _damage;

            // Custom event on damaged
            events.OnDamaged.Invoke();
        }

        public virtual void Die()
        {

            // Does it display killfeed on death? 
            if (showUI)
            {
                healthSlider.gameObject.SetActive(false);
            }
        }
    }
