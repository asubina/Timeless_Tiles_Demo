using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartManager : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject levelPanel;

    // Start is called before the first frame update
    void Start()
    {
        if (startPanel == null || levelPanel == null)
        {
            Debug.LogError("Panels are not assigned in the GameStartManager script.");
        }
        else
        {
            InitializePanels();
        }
    }

    // Initialize the panels' state
    private void InitializePanels()
    {
        startPanel.SetActive(true);
        levelPanel.SetActive(false);
        Debug.Log("InitializePanels: Start Panel is active, Level Panel is inactive.");
    }

    // Method to show the Start panel and hide the Level panel
    public void Home()
    {
        if (startPanel != null && levelPanel != null)
        {
            startPanel.SetActive(true);
            levelPanel.SetActive(false);
            Debug.Log("Home: Start panel activated, Level panel deactivated.");
        }
        else
        {
            Debug.LogError("Home: Panels are not assigned.");
        }
    }

    // Method to show the Level panel and hide the Start panel
    public void PlayGame()
    {
        if (startPanel != null && levelPanel != null)
        {
            startPanel.SetActive(false);
            levelPanel.SetActive(true);
            Debug.Log($"PlayGame: Level panel activated (activeSelf: {levelPanel.activeSelf}), Start panel deactivated.");
        }
        else
        {
            Debug.LogError("PlayGame: Panels are not assigned.");
        }
    }

    private void Update()
    {
        // Optional: Add any update logic here if needed
    }
}
