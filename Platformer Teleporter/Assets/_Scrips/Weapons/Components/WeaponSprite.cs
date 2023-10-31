
using Kien.Weapons.Components;
using System;
using System.Linq;
using UnityEngine;

namespace Kien.Weapons.Components
{
    public class WeaponSprite : WeaponComponent<WeaponSpriteData, AttackSprites>
    {
        private SpriteRenderer baseSpriteRenderer;
        private SpriteRenderer weaponSpriteRenderer;


        private int currentWeaponSpriteIndex;

        private Sprite[] currentPhaseSprites;


        protected override void HandleEnter()
        {
            base.HandleEnter();

            currentWeaponSpriteIndex = 0;
        }

        private void HandleEnterAttackPhase(AttackPhases phase)
        {
            currentWeaponSpriteIndex = 0;

            currentPhaseSprites = currentAttackData.PhaseSprites.FirstOrDefault(data => data.Phase == phase).Sprites;
        }
        private void HandleBaseSpriteChange(SpriteRenderer sr)
        {
            if (!isAttackActive)
            {
                weaponSpriteRenderer.sprite = null; return;
            }

            if (currentWeaponSpriteIndex >= currentPhaseSprites.Length)
            {
                Debug.LogWarning($"{weapons.name} weapons sprites legnth mismathch");
                return;
            }

            weaponSpriteRenderer.sprite = currentPhaseSprites[currentWeaponSpriteIndex];

            currentWeaponSpriteIndex++;
        }
      protected override void Start()
        {
            base.Start();


           baseSpriteRenderer = weapons.BaseGameObject.GetComponent<SpriteRenderer>();
           weaponSpriteRenderer = weapons.WeaponSpriteGameObject.GetComponent<SpriteRenderer>();

            data = weapons.Data.GetData<WeaponSpriteData>();

            baseSpriteRenderer.RegisterSpriteChangeCallback(HandleBaseSpriteChange);

            eventHandler.OnEnterAttackPhase += HandleEnterAttackPhase;

        }


        protected override void OnDestroy()
        {
            base.OnDestroy();

            baseSpriteRenderer.UnregisterSpriteChangeCallback(HandleBaseSpriteChange);


            eventHandler.OnEnterAttackPhase -= HandleEnterAttackPhase;


        }

    }


}
