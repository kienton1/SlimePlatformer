using Kien.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerAbilityState
{

    private int inputIndex;

    private Weapons weapons;
    public PlayerAttackState(Player player,
        PlayerStateMachine stateMachine,
        PlayerData playerData,
        string animBoolName,
        Weapons weapons,
        CombatInputs input)
        : base(player, stateMachine, playerData, animBoolName)
    {
        this.weapons = weapons;

        inputIndex = (int)input;

        weapons.OnExit += ExitHandler;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        weapons.CurrentInput = player.InputHandler.AttackInputs[inputIndex];
    }
    public override void Enter()
    {
        base.Enter();

        weapons.Enter();
    }

    private void ExitHandler()
    {
        AnimationFinishTrigger();
        isAbilityDone = true;
    }
}