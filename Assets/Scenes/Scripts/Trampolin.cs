using UnityEngine;

public class Trampolin : MonoBehaviour
{
    [SerializeField] private Collider2D DisableCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (DisableCollider != null)
            {
                DisableCollider.enabled = true;
            }
            other.gameObject.GetComponent<PlayerInput>().jump = true;
            other.gameObject.GetComponent<PlayerInput>().trampo = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (DisableCollider != null)
            {
                DisableCollider.enabled = false;
            }
            other.gameObject.GetComponent<PlayerInput>().trampo = false;
        }
    }
}
