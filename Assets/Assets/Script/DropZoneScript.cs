using UnityEngine;

public class DropZoneScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.InstantDeath();
        Debug.Log("Dead to dropzone");
    }
}
