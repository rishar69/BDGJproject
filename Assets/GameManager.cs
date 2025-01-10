using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public static GameManager Instance { get; private set; }


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
    private void Start()
    {


    }

    private void Update()
    {
    }

    public IEnumerator Dead()
    {
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);   
    }
}


