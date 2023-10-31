using System;
using UnityEditor;
using UnityEngine;

namespace Kien.Weapons
{
    public class AnimationEventHandler : MonoBehaviour
    {
        public event Action OnFinish;
        public event Action OnStartMovement;
        public event Action OnStopMovement;
        public event Action OnAttackAction;
        public event Action<AttackPhases> OnEnterAttackPhase;
        public event Action OnMinHoldPassed;
        public event Action OnSpawnArrow;
        private void AnimationFinishTrigger() => OnFinish?.Invoke();
        private void StartMovementTrigger() => OnStartMovement?.Invoke();
        private void StopMovementTrigger() => OnStopMovement?.Invoke();
        private void AttackActionTrigger() => OnAttackAction?.Invoke();
        private void MinHoldPassedTrigger() => OnMinHoldPassed?.Invoke();
        private void SpawnArrowFromAnimationEvent() => OnSpawnArrow?.Invoke();
        private void EnterAttackPhase(AttackPhases phase) => OnEnterAttackPhase ?.Invoke(phase);

    }
}
