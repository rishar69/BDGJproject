using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public AudioSource gameOver;
    public AudioSource bgm;
    public AudioSource countdownSound;

    private void Start()
    {
        // Automatically handle countdown when the scene loads
        Time.timeScale = 0f;
        StartCoroutine(CountdownCoroutine());
    }

    public void InstantDeath()
    {
        bgm.Stop();
        gameOver.Play();
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
    }

    public void RetryGame()
    {
        Debug.Log("Retrying game...");

        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ToMainMenu()
    {
       

        Time.timeScale = 1f;

        SceneManager.LoadScene("Main-Menu");
    }

    public IEnumerator CountdownCoroutine()
    {
        countdownSound.Play();
        Debug.Log("Countdown started.");
        yield return new WaitForSecondsRealtime(3f);
        Debug.Log("Countdown finished. Game started.");
        Time.timeScale = 1f;
        bgm.Play();
    }
}
