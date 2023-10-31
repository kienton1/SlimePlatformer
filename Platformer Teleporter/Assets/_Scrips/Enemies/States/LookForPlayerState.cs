using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kien.CoreSystem;

public class LookForPlayerState : State
{
    private Movement Movement { get => movement ?? core.GetCoreComponent<Movement>(); }
    private CollisionSenses CollisionSenses { get => collisionSenses ?? core.GetCoreComponent<CollisionSenses>(); }

    private Movement movement;
    private CollisionSenses collisionSenses;


    protected D_LookForPlayer stateData;

    protected bool turnImmediately;
    protected bool isPlayerInMinAgroRange;
    protected bool isAllTurnsDone;
    protected bool isAllTurnsTimeDone;

    protected float lastTurnTime;

    protected int amoutOfTurnsDone;
    public LookForPlayerState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_LookForPlayer stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
    }

    public override void Enter()
    {
        base.Enter();

        isAllTurnsDone = false;
        isAllTurnsTimeDone = false;

        lastTurnTime = startTime;

        lastTurnTime = startTime;
        amoutOfTurnsDone = 0;

        Movement?.SetVelocityX(0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        Movement?.SetVelocityX(0f);

        if (turnImmediately)
        {
            Movement?.Flip();
            lastTurnTime = Time.time;
            amoutOfTurnsDone++;
            turnImmediately = false;

        }
        else if (Time.time >= lastTurnTime + stateData.timeBetweenTurns && !isAllTurnsDone) 
        {
            Movement?.Flip();
            lastTurnTime = Time.time;
            amoutOfTurnsDone++;
        }

        if (amoutOfTurnsDone >= stateData.amountOfTurns)
        {
            isAllTurnsDone = true;

        }

        if (Time.time >= lastTurnTime + stateData.timeBetweenTurns && isAllTurnsDone)
        {
            isAllTurnsTimeDone = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public void SetTurnImmediately(bool flip)
    {
        turnImmediately = flip;
    }
}
