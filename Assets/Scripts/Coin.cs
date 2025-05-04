using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;
    public AudioClip coinSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CoinUI coinUI = FindFirstObjectByType<CoinUI>();
            if (coinUI != null)
            {
                coinUI.AddCoin(coinValue);
                AudioSource.PlayClipAtPoint(coinSound, transform.position, 15f);
            }

            Destroy(gameObject); 
        }
    }
}
