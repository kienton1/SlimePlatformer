using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kien.Weapons.Components
{
    public class DamageData : ComponentData<AttackDamage>
    {


        protected override void SetComponentDependency()
        {
            ComponenetDependency = typeof(Damage);
        }
    }
}
