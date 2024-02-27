using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class SceneControl : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetButtonDown("Reload"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
