using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kien.CoreSystem
{
    public class DamageReceiver : CoreComponent, IDamagable
    {
        [SerializeField] private GameObject damamgeParticles;

        private Stats stats;
        private ParticleManager particleManager;
        public void Damage(float amount)
        {

            stats.Health.Decrease(amount);
            particleManager.StartParticlesWithRandomRotation(damamgeParticles);
        }

        protected override void Awake()
        {
            base.Awake();

            stats = core.GetCoreComponent<Stats>();
            particleManager = core.GetCoreComponent<ParticleManager>();
        }
    }
}
