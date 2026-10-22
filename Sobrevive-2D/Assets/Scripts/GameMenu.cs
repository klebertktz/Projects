
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameMenu : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject gameOverPanel;
    public PlayerHealth playerHealth;

    private bool gameStart = false;

    void Start()
    {
        Time.timeScale = 0f;

        startPanel.SetActive(true);
        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (gameStart && playerHealth.life <= 0)
        {
            gameOverPanel.SetActive(true);
        }
    }

    public void StartGame()
    {
        gameStart = true;
        startPanel.SetActive(false);

        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        StartCoroutine(ReiniciarComSom());
    }

    IEnumerator ReiniciarComSom()
    {
        ButtonSound som = GetComponent<ButtonSound>();

        if (som != null && som.clickSound != null)
        {
            som.PlayClick();

            yield return new WaitForSecondsRealtime(
                som.clickSound.length
            );
        }

        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().name
        );
    }
}
