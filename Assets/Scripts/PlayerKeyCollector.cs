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

                if (levelCompleteUI != null)
                    levelCompleteUI.SetActive(true);

                
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                if (player != null)
                {
                    MonoBehaviour controller = player.GetComponent<PlayerController>();
                    if (controller != null)
                        controller.enabled = false;
                }

                
                StartCoroutine(LoadEndSceneWithDelay(5f));
            }
            else
            {
                Debug.Log("Don't Have Key");
            }
        }
    }

    private System.Collections.IEnumerator LoadEndSceneWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("End");
    }


}
