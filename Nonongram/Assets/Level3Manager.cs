using UnityEngine;
using UnityEngine.UI;

public class Level3Manager : MonoBehaviour
{
    public Button[] gridButtons;  // Assign buttons in the Unity Inspector
    public Text livesText;        // Display lives
    private int lives = 3;
    private bool isXMode = true;

    void Start()
    {
        UpdateLivesUI();
        AssignButtonListeners();
    }

    void AssignButtonListeners()
    {
        foreach (Button button in gridButtons)
        {
            button.onClick.AddListener(() => OnGridButtonClick(button));
        }
    }

    void OnGridButtonClick(Button button)
    {
        if (isXMode)
        {
            button.GetComponentInChildren<Text>().text = "X";
        }
        else
        {
            button.GetComponent<Image>().color = Color.black;
        }

        if (CheckForMistake(button))
        {
            lives--;
            UpdateLivesUI();
            if (lives <= 0)
            {
                GameOver();
            }
        }
    }

    public void ToggleXOrColor()
    {
        isXMode = !isXMode;
    }

    void UpdateLivesUI()
    {
        livesText.text = "Lives: " + lives;
    }

    bool CheckForMistake(Button button)
    {
        return false; // Implement mistake-checking logic
    }

    void GameOver()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LoseScene");
    }

    public void WinLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("WinScene");
    }
}
