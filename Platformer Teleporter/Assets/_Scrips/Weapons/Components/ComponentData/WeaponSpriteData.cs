using UnityEngine;
using Kien.Weapons.Components;

namespace Kien.Weapons.Components
{
    public class WeaponSpriteData : ComponentData<AttackSprites>
    {


        protected override void SetComponentDependency()
        {
            ComponenetDependency = typeof(WeaponSprite);
        }
    }
}
