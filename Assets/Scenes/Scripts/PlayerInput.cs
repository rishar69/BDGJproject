using UnityEngine;
public class PlayerInput : MonoBehaviour
{
    public PlayerController Controller;
    public Animator animator;
    public float Speed = 40f;
    public bool jump = false;
    float horizontalMove = 0f;
    void Awake()
    {
        Controller = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        getInput();
    }
    void FixedUpdate()
    {
        Execute();
    }
    private void getInput()
    {
        horizontalMove = Input.GetAxis("Horizontal") * Speed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }
    public void OnJump()
    {
        animator.SetBool("isJump", true);
        Debug.Log("JumpingC");
    }
    public void onLanding()
    {
        animator.SetBool("isJump", false);
    }
    private void Execute()
    {
        Controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
        // Debug.Log(horizontalMove * Time.fixedDeltaTime + " " + crouch + " " + jump);
    }
}