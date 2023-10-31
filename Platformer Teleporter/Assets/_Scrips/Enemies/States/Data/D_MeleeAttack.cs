using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="newmeleeAttackStateData", menuName ="Data/State Data/Melee Attack State")]
public class D_MeleeAttack : ScriptableObject
{
    public float attackRadius = 0.5f;
    public float attackDamage = 10f;
    public Vector2 knockbackAngle = Vector2.one;
    public float knockbackStregnth = 10f;

    public LayerMask whatIsPlayer;
}
