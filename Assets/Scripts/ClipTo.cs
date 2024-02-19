using UnityEngine;

public sealed class ClipTo : MonoBehaviour
{
    public GameObject lastTouched;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            var sphere = GameObject.Find("Sphere");
            if (sphere != null)
            {
                transform.position = sphere.transform.position;
            }
        }
    }
}
