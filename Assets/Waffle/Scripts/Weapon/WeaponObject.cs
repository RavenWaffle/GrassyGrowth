using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
    public class WeaponObject : MonoBehaviour
    {
        [SerializeField] private Weapon.WeaponData wd = new Weapon.WeaponData();
        public bool canAttack;

        public IEnumerator Attack(Entity target)
        {
            canAttack = false;
            yield return new WaitForSeconds(wd.windUpTime);
            target.SetHealth(target.health - wd.damage);
            yield return new WaitForSeconds(wd.coolDownTime);
            canAttack = true;
        }
    }
}
