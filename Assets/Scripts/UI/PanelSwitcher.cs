using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSwitcher : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject levelPanel;

    void Start()
    {
        InitializePanels();
    }

    void InitializePanels()
    {
        if (PlayerPrefs.GetInt("GoToLevelSelect", 0) == 1)
        {
            ShowLevelPanel();
            PlayerPrefs.SetInt("GoToLevelSelect", 0); // Reset the flag
        }
        else
        {
            ShowStartPanel();
        }
    }

    public void ShowStartPanel()
    {
        if (startPanel != null && levelPanel != null)
        {
            startPanel.SetActive(true);
            levelPanel.SetActive(false);
            // Debug.Log("ShowStartPanel: Start panel activated, LevelSelect panel deactivated.");
        }
    }

    public void ShowLevelPanel()
    {
        if (startPanel != null && levelPanel != null)
        {
            startPanel.SetActive(false);
            levelPanel.SetActive(true);
            // Debug.Log("ShowLevelPanel: LevelSelect panel activated, Start panel deactivated.");
        }
    }
}
