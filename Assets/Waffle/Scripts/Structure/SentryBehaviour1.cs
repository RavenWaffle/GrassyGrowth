using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Structure
{
    public class WellBehaviour : MonoBehaviour
    {
        EntityStructureWell Base;
        [SerializeField] GameObject Lid;
        public bool isActive;
        void Start()
        {
            Base = this.GetComponent<EntityStructureWell>();
        }

        private void FixedUpdate()
        {
            BehaviourHandler();
        }

        void BehaviourHandler()
        {
            if (isActive)
            {
                Base.enabled = true;
                Lid.SetActive(true);
            }
            else
            {
                Base.enabled = false;
                Lid.SetActive(false);
            }
        }
    }
}
