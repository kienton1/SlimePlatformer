
using UnityEngine;
using System;
using Kien.CoreSystem;
using System.Collections.Generic;

namespace Kien.Weapons.Components
{
    public abstract class WeaponComponent : MonoBehaviour
    {
        protected Weapons weapons;

        //protected AnimationEventHandler EventHandler => weapons.EventHandler;

        protected AnimationEventHandler eventHandler;
        protected Core Core => weapons.Core;

        public List<WeaponComponent> ToList { get; internal set; }

        protected bool isAttackActive;

        public virtual void Init()
        {

        }
        protected virtual void Awake()
        {
            weapons = GetComponent<Weapons>();

            eventHandler = GetComponentInChildren<AnimationEventHandler>();

        }

        protected virtual void Start()
        {
            weapons.OnEnter += HandleEnter;
            weapons.OnExit += HandleExit;
        }

        protected virtual void HandleEnter()
        {
            isAttackActive = true;
        }

        protected virtual void HandleExit()
        {
            isAttackActive = false;
        }



        protected virtual void OnDestroy()
        {
            weapons.OnEnter -= HandleEnter;
            weapons.OnExit -= HandleExit;
        }
    }

    public abstract class  WeaponComponent<T1, T2> : WeaponComponent where T1 : ComponentData<T2> where T2 : AttackData
    {
        protected T1 data;
        protected T2 currentAttackData;

        protected override void HandleEnter()
        {
            base.HandleEnter();

            currentAttackData = data.AttackData[weapons.CurrentAttackCounter];
        }

        public override void Init()
        {
            base.Init();

            data = weapons.Data.GetData<T1>();
        }
    }
}
