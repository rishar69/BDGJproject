using UnityEngine;

public class Sticky : MonoBehaviour
{
    [SerializeField] private AudioSource stickySound;
    private void OnTriggerEnter2D(Collider2D other)
    {
        var playerInput = other.gameObject.GetComponent<PlayerInput>();
        if (playerInput != null)
        {
            stickySound.Play();
            playerInput.isSticky = true;
        }
        else
        {
            Debug.LogError("PlayerInput is missing on " + other.gameObject.name);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerInput>().isSticky = false;
        }
    }
}