using UnityEngine;

public sealed class CursorLock : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
