using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true; 
            print("triggered");
            StartCoroutine(WaitForFall());
        }
    }

    private IEnumerator WaitForFall()
    {
        yield return new WaitForSeconds(0.5f);
        Rigidbody2D rb = gameObject.AddComponent<Rigidbody2D>();
        rb.gravityScale = 2f;
    }
}
