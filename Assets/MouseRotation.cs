using UnityEngine;

public sealed class MouseRotation : MonoBehaviour
{
    public Vector2 turn;

    private void Update()
    {
        turn.x += Input.GetAxis("Mouse X");
        turn.y += Input.GetAxis("Mouse Y");

        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
    }
}
