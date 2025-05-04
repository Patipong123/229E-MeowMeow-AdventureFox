using UnityEngine;

public class Berry : MonoBehaviour
{
    public int berryValue = 1;
    public AudioClip coinSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            BerryUI berryUI = FindFirstObjectByType<BerryUI>();
            if (berryUI != null)
            {
                berryUI.AddBerry(berryValue);
                AudioSource.PlayClipAtPoint(coinSound, transform.position, 15f);
            }

            Destroy(gameObject); 
        }
    }
}
