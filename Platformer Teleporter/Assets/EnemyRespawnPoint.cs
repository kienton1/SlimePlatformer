using UnityEngine;

public class EnemyRespawnPoint : MonoBehaviour
{
    // This script is intended to be attached to empty GameObjects
    // to mark the respawn points for enemies.

    // You can add any additional variables or customization specific to your game here.

    private void OnDrawGizmos()
    {
        // This function draws a gizmo in the Unity editor to make it easier to visualize the respawn points.

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1f); // Adjust the size of the gizmo sphere if needed.
    }
}
