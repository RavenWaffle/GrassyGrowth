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

        public void GiveOrder(ref Transform Target, Vector3 soldierTransform)
        {
            List<Structure.EntityStructureSentry> _sentry = FindObjectsOfType<Structure.EntityStructureSentry>().ToList();
            List<Structure.EntityStructureRabbitHole> _rabbitHole = FindObjectsOfType<Structure.EntityStructureRabbitHole>().ToList();
            List<Structure.EntityStructureWell> _well = FindObjectsOfType<Structure.EntityStructureWell>().ToList();
            List<Player.EntityPlayer> _player = FindObjectsOfType<Player.EntityPlayer>().ToList();

            List<Structure.EntityStructureSentry> hitlist1 = _sentry.OrderBy(e => Vector2.Distance(e.transform.position, soldierTransform)).ToList();
            if(hitlist1.Count > 0)
            {
                Target = hitlist1[0].gameObject.transform;
            }

        }
    }
}
