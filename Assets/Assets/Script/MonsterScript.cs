using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class MonsterScript : MonoBehaviour
{
    public float duration = 0;
    public float treshold;
    public float moveSpeed;
    private bool isInsideTrigger = false;
    public GameObject playerPosition;
    private float distanceTreshold = 20f;
    public AudioSource splat;

    public GameObject gameManager;
    public GameObject gameOverUI;
    private AudioSource gameOverSound;
    private AudioSource bgm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        bgm = gameManager.GetComponent<GameManager>().bgm;
        gameOverSound = gameManager.GetComponent<GameManager>().gameOver;

    }

   

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, playerPosition.transform.position);

        if (distance <= distanceTreshold)
        {
            CameraScripts.Instance.ShakeCamera(1);
        }
        else
        {
            CameraScripts.Instance.ShakeCamera(0);
        }
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;

        if (isInsideTrigger)
        {
            duration += Time.deltaTime;
            print(duration);

            if (duration > treshold)
            {
                playerPosition.GetComponent<PlayerInput>().Speed = 0;
                StartCoroutine(Dead(0.1f));
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        splat.Play();
        isInsideTrigger = true;
        Debug.Log("Trigger enter true");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInsideTrigger = false;

        duration = 0;
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
