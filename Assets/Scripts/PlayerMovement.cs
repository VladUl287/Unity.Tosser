using UnityEngine;

public sealed class Movement : MonoBehaviour
{
    private Rigidbody rgBody;

    public Transform groundCheck;
    public LayerMask groundLayer;

    public float MoveSpeed = 5F;
    public float JumpForce = 5F;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        rgBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var moveVertical = vertical * MoveSpeed * Time.deltaTime * Camera.main.transform.forward;
        var moveHorizontal = horizontal * MoveSpeed * Time.deltaTime * Camera.main.transform.right;
        var position = moveVertical + moveHorizontal + transform.position;
        position.y = transform.position.y;
        transform.position = position;

        //var moveVertical = vertical * MoveSpeed * Time.deltaTime * Camera.main.transform.forward;
        //var moveHorizontal = horizontal * MoveSpeed * Time.deltaTime * Camera.main.transform.right;
        //var position = moveVertical + moveHorizontal;
        //position.y = 0;
        //rgBody.velocity += position;

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }
    }

    private void Jump()
    {
        rgBody.velocity = new Vector3(0, JumpForce, 0);
    }

    private bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1F, groundLayer);
    }
}
