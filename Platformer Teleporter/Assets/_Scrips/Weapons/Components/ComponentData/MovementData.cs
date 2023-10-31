using Kien.Weapons.Components;
using UnityEngine;

namespace Kien.Weapons.Components
{
    public class MovementData : ComponentData<AttackMovement>
    {


        protected override void SetComponentDependency()
        {
            ComponenetDependency = typeof(Movement);
        }
    }
}