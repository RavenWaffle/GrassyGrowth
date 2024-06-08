using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Structure
{
    public class EntityStructureSentry : Entity
    {
        [SerializeField] private float _range;
        public float Range => _range;

    }
}
