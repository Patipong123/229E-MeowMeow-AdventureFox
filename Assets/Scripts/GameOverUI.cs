using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public GameObject retryButton;

    void Start()
    {
        retryButton.SetActive(false); 
        retryButton.GetComponent<Button>().onClick.AddListener(RestartGame);
    }

    public void ShowRetry()
    {
        gameObject.SetActive(true);

        if (retryButton != null)
            retryButton.SetActive(true);
    }

    void RestartGame()
    {
        Time.timeScale = 1f; 
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }
}

