using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kien.Weapons.Components
{
    [Serializable]
    public class AttackDamage : AttackData
    {
        [field: SerializeField] public float Amount {  get; private set; }

    }
}
