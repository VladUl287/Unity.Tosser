using UnityEngine;

public sealed class Rebound : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ReboundSurface"))
        {

        }
    }
}
