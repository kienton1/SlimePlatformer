using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kien.Weapons.Components
{
    public class ActionHitBoxData : ComponentData<AttackActionHitBox>
    {


        [field: SerializeField] public LayerMask DetectalbeLayers { get; private set; }


        protected override void SetComponentDependency()
        {
            ComponenetDependency = typeof(ActionHitBox);
        }
    }
}
