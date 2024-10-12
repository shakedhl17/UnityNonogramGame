using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level1Manager : MonoBehaviour
{
    public Button[] gridButtons;  // Assign buttons from the Unity Inspector
    public Text livesText;        // Text element to display lives
  
    private int mistakes = 0;        // Player has 3 lives
    public Image[] hearts; // Assign the hearts in the inspector

    private List<int> correctButtons = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 13, 14, 15, 16, 20, 21, 23, 24 };// List of correct buttons that should be clicked (black buttons)
    private HashSet<int> clickedCorrectButtons = new HashSet<int>();// To track clicked correct buttons

    void Start()
    {
        // Add click listeners to buttons
        for (int i = 0; i < gridButtons.Length; i++)
        {
            int buttonIndex = i; // Capture the index for the lambda
            gridButtons[buttonIndex].onClick.AddListener(() => OnButtonClick(buttonIndex));
        }
    }

    void OnButtonClick(int index)
    {
        // Check if the clicked button is a correct one
        if (correctButtons.Contains(index))
        {
            // Mark the button as clicked and turn it black
            gridButtons[index].GetComponent<Image>().color = Color.black;
            gridButtons[index].interactable = false; // Disable further clicks
            clickedCorrectButtons.Add(index);

            // Check for win condition
            if (clickedCorrectButtons.Count == correctButtons.Count)
            {
                WinLevel();
            }
        }
        else
        {
            // If it's an incorrect button, remove a heart and check lose condition
            mistakes++;
            RemoveHeart();

            if (mistakes >= 3)
            {
                LoseLevel();
            }
        }
    }

    void RemoveHeart()
    {
        if (mistakes <= hearts.Length)
        {
            hearts[mistakes - 1].color = new Color(1, 1, 1, 0); // Set the alpha to 0 (transparent)
        }
    }


    void WinLevel()
    {
        // Load the Win scene
        SceneManager.LoadScene("Level2");
    }

    void LoseLevel()
    {
        // Load the Lose scene
        SceneManager.LoadScene("LoseScene");
    }
}