using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Enemy
{
    public class EnemyCommander : MonoBehaviour
    {
        private void FixedUpdate()
        {
        }

        public void GiveOrder(ref Entity Target, Vector3 soldierTransform)
        {
            List<Entity> _entities = FindObjectsOfType<Entity>().ToList();
            _entities.RemoveAll(e => e.TryGetComponent<Enemy.EntityEnemy>(out EntityEnemy none));
            _entities.RemoveAll(e => !e.enabled);
            _entities = _entities.OrderBy(e => Vector2.Distance(e.transform.position, soldierTransform)).ToList();
            if (_entities.Count > 0)
            {
                Target = _entities[0];
                Debug.Log(_entities[0].gameObject.name);
            }
        }
    }
}
