using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void RestartLevel()
    {
        // Reload the current active level
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
