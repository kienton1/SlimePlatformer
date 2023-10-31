using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kien.CoreSystem;
public class MeleeAttackState : AttackState
{
    private Movement Movement { get => movement ?? core.GetCoreComponent<Movement>(); }
    private CollisionSenses CollisionSenses { get => collisionSenses ?? core.GetCoreComponent<CollisionSenses>(); }

    private Movement movement;
    private CollisionSenses collisionSenses;


    protected D_MeleeAttack stateData;


    public MeleeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_MeleeAttack stateData) : base(entity, stateMachine, animBoolName, attackPosition)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

    }

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();

        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attackPosition.position, stateData.attackRadius, stateData.whatIsPlayer);

        foreach (Collider2D collider in detectedObjects)
        {
            IDamagable damagable = collider.GetComponent<IDamagable>();

            if (damagable != null)
            {
                damagable.Damage(stateData.attackDamage);
            }

            IKnockBackable knockbackable = collider.GetComponent<IKnockBackable>();

            if (knockbackable != null)
            {
                knockbackable.KnockBack(stateData.knockbackAngle, stateData.knockbackStregnth, Movement.FacingDirection);
            }
        }
    }
}
