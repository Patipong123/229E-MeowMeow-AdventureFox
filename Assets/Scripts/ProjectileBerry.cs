using UnityEngine;

public class ProjectileBerry : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyTargetMarker enemy = other.GetComponent<EnemyTargetMarker>();
            if (enemy != null)
            {
                enemy.Die(); 
            }

            Destroy(gameObject); 
        }
        else if (!other.isTrigger)
        {
            Destroy(gameObject); 
        }
    }
}

