using UnityEngine;

public sealed class MouseRotation : MonoBehaviour
{
    [Range(1f, 10f)] public float sensitivity = 5f;
    [Range(0f, 90f)] public float yRotationLimit = 90f;

    private Vector2 turn;

    private void Update()
    {
        turn.x += Input.GetAxis("Mouse X");
        turn.y += Input.GetAxis("Mouse Y");

        turn.y = Mathf.Clamp(turn.y, -yRotationLimit, yRotationLimit);

        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
    }
}
