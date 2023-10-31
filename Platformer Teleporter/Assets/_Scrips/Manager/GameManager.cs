using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private float respawnTime;

    private float respawnTimeStart;
    private bool respawn;

    private void Update()
    {
        CheckRespawn();
    }

    public void Respawn()
    {
        respawnTimeStart = Time.time;
        respawn = true;
    }

    private void CheckRespawn()
    {
        if (Time.time >= respawnTimeStart + respawnTime && respawn)
        {
            // Instantiate the player at the respawn point
            GameObject player = Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
            Debug.Log("Respawinging a prefab");

            // Update the camera's target to follow the new player
            MultipleTargetCamera cameraController = Camera.main.GetComponent<MultipleTargetCamera>();
            if (cameraController != null)
            {
                cameraController.targets.Clear(); // Clear existing targets
                cameraController.AddTarget(player.transform); // Add the new player as the target
            }

            respawn = false;
        }
    }
}
