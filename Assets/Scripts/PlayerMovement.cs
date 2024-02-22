using UnityEngine;

public sealed class Movement : MonoBehaviour
{
    private Rigidbody rigidBody;
    private bool RunHeldDown = false;

    public Transform ground;
    public LayerMask groundLayer;

    public float NormalMoveSpeed = 7F;
    public float HighMoveSpeed = 10F;
    public float JumpForce = 10F;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        SetRunHeldDown();

        var speed = GetSpeed();

        Move(transform, speed);

        JumpByDown();
    }

    private void SetRunHeldDown()
    {
        if (Input.GetButtonDown("Run"))
        {
            RunHeldDown = true;
        }
        else if (Input.GetButtonUp("Run"))
        {
            RunHeldDown = false;
        }
    }

    private float GetSpeed()
    {
        if (RunHeldDown)
        {
            return HighMoveSpeed;
        }
        return NormalMoveSpeed;
    }    

    private static void Move(Transform transform, float speed)
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var moveVertical = vertical * speed * Time.deltaTime * Camera.main.transform.forward;
        var moveHorizontal = horizontal * speed * Time.deltaTime * Camera.main.transform.right;
        var position = moveVertical + moveHorizontal + transform.position;
        position.y = transform.position.y;
        transform.position = position;
    }

    private void JumpByDown()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded(ground, groundLayer))
        {
            Jump(rigidBody, JumpForce);
        }
    }

    private static void Jump(Rigidbody rigidbody, float force)
    {
        rigidbody.velocity = new Vector3(0, force, 0);
    }

    private static bool IsGrounded(Transform transform, LayerMask layer)
    {
        return Physics.CheckSphere(transform.position, .1F, layer);
    }
}
