using UnityEngine;

public sealed class ClipTo : MonoBehaviour
{
    private static GameObject LastTouched;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt) && LastTouched != null)
        {
            transform.position = LastTouched.transform.position;
        }
    }

    public static void SetLastTouched(GameObject gameObject)
    {
        LastTouched = gameObject;
    }
}
