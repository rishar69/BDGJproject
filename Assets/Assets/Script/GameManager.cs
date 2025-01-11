using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public static GameManager Instance { get; private set; }
    [SerializeField] private AudioSource gameOver;
    [SerializeField] private AudioSource bgm;
    [SerializeField] private AudioSource countdownSound;
    [SerializeField] private GameObject countdownUI;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; 
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Debug.LogError("Duplicate GameManager found! Destroying the new one.");
            Destroy(gameObject);
        }
    }
    public void InstantDeath()
    {
        bgm.Stop();
        gameOver.Play();
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
    }
    public IEnumerator Dead(float timeBeforeDeath)
    {
        bgm.volume=0.2f;
        yield return new WaitForSeconds(timeBeforeDeath);
        bgm.Stop();
        gameOver.Play();
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);   
    }
}


