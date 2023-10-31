using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kien.Weapons.Components
{
    public class PoiseDamageData : ComponentData<AttackPoiseDamage>
    {
        protected override void SetComponentDependency()
        {
            ComponenetDependency = typeof(PoiseDamage);
        }
    }
}
