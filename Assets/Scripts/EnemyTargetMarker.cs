using UnityEngine;

public class EnemyTargetMarker : MonoBehaviour
{
    public KeyDropManager keyDropManager;

    public void Die()
    {
        if (keyDropManager != null)
        {
            keyDropManager.NotifyEnemyKilled(gameObject);
        }

        Destroy(gameObject); 
    }
}
