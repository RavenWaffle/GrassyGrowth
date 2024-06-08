using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Enemy
{
    public class EnemyCommander : MonoBehaviour
    {
        List<Structure.EntityStructureSentry> _allSentry;
        List<Player.EntityPlayer> _players;

        List<Entity> _mix;

        private void FixedUpdate()
        {
            _allSentry = FindObjectsOfType<Structure.EntityStructureSentry>().ToList();
            _players = FindObjectsOfType<Player.EntityPlayer>().ToList();

            //_mix = _allSentry.Concat(_players).ToList();
        }

        public void GiveOrder(ref Transform Target)
        {

        }
    }
}
