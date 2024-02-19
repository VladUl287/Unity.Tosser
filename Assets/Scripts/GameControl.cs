using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class GameControl : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Reload"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
