using Kien.Weapons.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Kien.Weapons
{
    public class WeaponGenerator : MonoBehaviour
    {
        [SerializeField] private Weapons weapons;
        [SerializeField] private WeaponDataSO data;

        private List<WeaponComponent> componentsAlreadyOnWeapon = new List<WeaponComponent>();

        private List<WeaponComponent> componentsAddedToWeapon = new List<WeaponComponent>();

        private List<Type> componentDependencies = new List<Type>();

        private Animator anim;

        private void Start()
        {
            anim = GetComponentInChildren<Animator>();
            GenerateWeapon(data);
        }

        private void TestGeneration()
        {
            GenerateWeapon(data);
        }

        [ContextMenu("Test Generate")]
        public void GenerateWeapon(WeaponDataSO data)
        {
            weapons.SetData(data);

            componentsAlreadyOnWeapon.Clear();
            componentsAddedToWeapon.Clear();
            componentDependencies.Clear();

            componentsAlreadyOnWeapon = GetComponents<WeaponComponent>().ToList();

            componentDependencies = data.GetAllDependencies();

            foreach (var dependency in componentDependencies)
            {
                if (componentsAddedToWeapon.FirstOrDefault(component => component.GetType() == dependency))
                    continue;

                var weaponComponent =
                    componentsAlreadyOnWeapon.FirstOrDefault(component => component.GetType() == dependency);

                if (weaponComponent == null)
                {
                    weaponComponent = gameObject.AddComponent(dependency) as WeaponComponent;
                }

                weaponComponent.Init();

                componentsAddedToWeapon.Add(weaponComponent);


            }

            var componentsToRemove = componentsAlreadyOnWeapon.Except(componentsAddedToWeapon);

            foreach (var weaponComponent in componentsToRemove)
            {
                Destroy(weaponComponent);
            }

            anim.runtimeAnimatorController = data.AnimatorController;
        }
    }
}
