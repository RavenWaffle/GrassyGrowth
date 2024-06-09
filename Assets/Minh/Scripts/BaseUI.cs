#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AI;
using UnityEngine.Events;

    public class BaseUI : MonoBehaviour
    {
        public float health;


        [Tooltip("initial enemy health "), SerializeField]
        public float maxHealth;


        [Tooltip("display enemy status via UI"), SerializeField]
        protected Slider healthSlider;


        [Tooltip("Colour for the specific status to be displayed in the slider"), SerializeField]
        private Color healthColor;
        

        public Entity entity;


        // Start is called before the first frame update"
        public virtual void Start()
        {

            entity = this.gameObject.GetComponent<Entity>();
            // Status initial settings
            maxHealth = entity.Health;


            // UI 
            // Determine max values
            if (healthSlider != null) healthSlider.maxValue = maxHealth;

        }

        // Update is called once per frame
        public virtual void Update()
        {
            //Debug.Log(entity.Health);
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

        }

        public virtual void Die()
        {
                healthSlider.gameObject.SetActive(false);
        }
    }