using UnityEngine;

public class KeyItem : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerKeyCollector player = collision.gameObject.GetComponent<PlayerKeyCollector>();
            if (player != null)
            {
                player.CollectKey();
                Destroy(gameObject); 
            }
        }
    }
}
