using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kien.Weapons.Components
{
    public class KnockBackData : ComponentData<AttackKnockBack>
    {
        protected override void SetComponentDependency()
        {
            ComponenetDependency = typeof(KnockBack);
        }
    }
}
