using UnityEngine;

public class Sticky : MonoBehaviour
{
    [SerializeField] private AudioSource stickySound;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            stickySound.Play();
            bool isSticky = other.gameObject.GetComponent<PlayerInput>().isSticky = true;     
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