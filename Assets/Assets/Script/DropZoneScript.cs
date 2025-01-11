using UnityEngine;

public class DropZoneScript : MonoBehaviour
{
    private AudioSource scream;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        scream = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        scream.Play();
        StartCoroutine(GameManager.Instance.Dead(0.5f));
        Debug.Log("Dead to dropzone");
    }
    
}
