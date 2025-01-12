using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject GameFinish;
    private AudioSource gameFinishSound;
    private AudioSource bgm;
    public AudioSource finishReachedSound;
    public AudioSource finishBGM;


    private void Awake()
    {
        bgm = gameManager.GetComponent<GameManager>().bgm;
        gameFinishSound = gameManager.GetComponent<GameManager>().gameFinishSound;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            finishReachedSound.Play();
            StartCoroutine(Goal(0.1f));
            Debug.Log("Dead to dropzone");
        }
    }

    public IEnumerator Goal(float timeBeforeDeath)
    {
        bgm.volume = 0.2f;
        yield return new WaitForSeconds(timeBeforeDeath);
        bgm.Stop();
        gameFinishSound.Play();
        finishBGM.Play();
        Time.timeScale = 0f;
        GameFinish.SetActive(true);
    }

}
