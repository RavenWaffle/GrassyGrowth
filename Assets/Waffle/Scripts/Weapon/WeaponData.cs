using UnityEngine;

namespace Weapon
{
    [CreateAssetMenu(fileName = "WeaponData", menuName = "Weapon/Weapon data", order = 0)]
    public class WeaponData : ScriptableObject
        {
            public float damage;
            public float windUpTime;
            public float coolDownTime;
        }
}

