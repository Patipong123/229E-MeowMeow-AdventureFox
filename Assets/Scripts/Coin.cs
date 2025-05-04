using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CoinUI coinUI = FindFirstObjectByType<CoinUI>();
            if (coinUI != null)
            {
                coinUI.AddCoin(coinValue);
            }

            Destroy(gameObject); 
        }
    }
}
