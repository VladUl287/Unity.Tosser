using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class GameControl : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetButtonDown("Reload"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
