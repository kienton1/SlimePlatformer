using UnityEngine;
using Kien.CoreSystem.StatsSystem;
using UnityEngine.SceneManagement;

namespace Kien.CoreSystem
{
    public class Stats : CoreComponent
    {
        [field: SerializeField] public Stat Health { get; private set; }
        [field: SerializeField] public Stat Poise { get; private set; }

        [SerializeField] private float poiseRecoveryRate;

        protected override void Awake()
        {
            base.Awake();

            Health.Init();
            Poise.Init();

            // Subscribe to the health reaching zero event to handle player death
            Health.OnCurrentValueZero += HandlePlayerDeath;
            Debug.Log("OnCureentValeuZero");
            ;
        }

        private void Update()
        {
            if (Poise.CurrentValue.Equals(Poise.MaxValue))
                return;

            Poise.Increase(poiseRecoveryRate * Time.deltaTime);
        }

        private void HandlePlayerDeath()
        {
            // Wait for 1 second before checking if the player exists
            Invoke("CheckForPlayer", 1f);

        }

        private void CheckForPlayer()
        {
            // Check if the player exists in the scene
            GameObject player = GameObject.FindGameObjectWithTag("Player"); // Change "Player" to your player tag

            if (player == null)
            {
                // Player exists, handle their death
                // Add logic to handle the player's death here (e.g., play death animation, trigger respawn, etc.)
                // Then, call the Respawn method from your GameManager
                Health.OnCurrentValueZero -= HandlePlayerDeath;
                FindObjectOfType<GameManager>().Respawn();
                Scene currentScene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(currentScene.name);
                Debug.Log("Respawn");
            }
            else
            {
                // Player doesn't exist, handle this case (e.g., show a message, restart the scene, etc.)
                Debug.Log("Player not found. Handle this case accordingly.");
            }
        }


    }
}