using System.Collections;
using UnityEngine;

public class DropZoneScript : MonoBehaviour
{
    private AudioSource scream;
    public GameObject gameManager;
    public GameObject gameOverUI;
    private AudioSource gameOverSound;
    private AudioSource bgm;


    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        scream = GetComponent<AudioSource>();
        bgm = gameManager.GetComponent<GameManager>().bgm;
        gameOverSound = gameManager.GetComponent<GameManager>().gameOver;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
        scream.Play();
        StartCoroutine(Dead(0.3f));
        Debug.Log("Dead to dropzone");    
        }
    }

    
    public IEnumerator Dead(float timeBeforeDeath)
    {
        bgm.volume = 0.2f;
        yield return new WaitForSeconds(timeBeforeDeath);
        bgm.Stop();
        gameOverSound.Play();
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
    }
}
