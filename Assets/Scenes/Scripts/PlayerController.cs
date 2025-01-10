using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float MainjumpForce = 10f;
    [Range(0, .3f)][SerializeField] private float movementSmoothing = .05f;
    [SerializeField] private bool airControl = false;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform groundCheck;

    public GameObject onJumpEffect;
    const float groundedRadius = .2f;
    private bool grounded;
    const float ceilingRadius = .2f;
    private Rigidbody2D rb2D;
    private bool isFacingRight = true;
    private Vector3 velocity = Vector3.zero;

    [Header("Events")]
    [Space]
    public UnityEvent OnLandEvent;
    public UnityEvent OnJumpEvent;
    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();
    }
    void Update()
    {
        OnAir();
    }
    void FixedUpdate()
    {
        groundChecking();
    }
    public void Move(float move, bool jump, bool sticky)
    {
        float ExecJumpForce = MainjumpForce;
        if (sticky)
        {
            ExecJumpForce = MainjumpForce / 2;
        }
        if (grounded || airControl)
        {
            Vector3 targetVelocity = new Vector2(move * 10f, rb2D.linearVelocity.y);
            rb2D.linearVelocity = Vector3.SmoothDamp(rb2D.linearVelocity, targetVelocity, ref velocity, movementSmoothing);

            if (move > 0 && !isFacingRight)
            {
                Flip();
            }
            else if (move < 0 && isFacingRight)
            {
                Flip();
            }
        }
        if (jump && grounded)
        {
            grounded = false;
            rb2D.AddForce(new Vector2(0f, ExecJumpForce), ForceMode2D.Impulse);
            Instantiate(onJumpEffect, transform.position, transform.rotation);
        }
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    public void OnAir()
    {
        if (!grounded)
        {
            if (rb2D.linearVelocity.y > 0)
            {
                OnJumpEvent.Invoke();
            }
        }
    }
    private void groundChecking()
    {
        bool wasGrounded = grounded;
        grounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                grounded = true;
                if (!wasGrounded)
                {
                    OnLandEvent.Invoke();
                    Instantiate(onJumpEffect, transform.position, transform.rotation);
                }
            }
        }
    }
}
