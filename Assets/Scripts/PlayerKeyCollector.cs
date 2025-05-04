using UnityEngine;
using UnityEngine.SceneManagement; 

public class PlayerKeyCollector : MonoBehaviour
{
    private bool hasKey = false;
    public GameObject levelCompleteUI;

    public void CollectKey()
    {
        hasKey = true;
        Debug.Log("Key collected!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pass"))
        {
            if (hasKey)
            {
                Debug.Log("Game Complete!");
                Time.timeScale = 0f;

                if (levelCompleteUI != null)
                    levelCompleteUI.SetActive(true); 
            }
            else
            {
                Debug.Log("Don't Have Key");
            }
        }
    }


}
