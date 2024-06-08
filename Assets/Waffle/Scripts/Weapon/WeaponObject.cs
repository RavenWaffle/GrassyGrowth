using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
    public class WeaponObject : MonoBehaviour
    {
        [SerializeField] private Weapon.WeaponData wd;
        public bool canAttack = true;
        public bool attacking;

        public IEnumerator Attack(Entity target)
        {
            canAttack = false;
            attacking = true;
            Debug.Log(target.name);
            yield return new WaitForSeconds(wd.windUpTime);
            target.SetHealth(target.Health - wd.damage);
            yield return new WaitForSeconds(wd.coolDownTime);
            attacking = false;
            canAttack = true;
        }
    }
}
