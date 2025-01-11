using UnityEngine;

public class Trampolin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            float jumpSpeed = other.gameObject.GetComponent<Rigidbody2D>().linearVelocity.y;
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -jumpSpeed), ForceMode2D.Impulse);
            other.gameObject.GetComponent<PlayerInput>().jump = true;
            other.gameObject.GetComponent<PlayerInput>().Jboost = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerInput>().Jboost = false;
        }
    }
}
