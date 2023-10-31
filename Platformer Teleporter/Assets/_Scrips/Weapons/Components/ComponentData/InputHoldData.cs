using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kien.Weapons.Components
{
    public class InputHoldData : ComponentData
    {

        protected override void SetComponentDependency()
        {
            ComponenetDependency = typeof(InputHold);
        }
    }
}
