using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSwitcher : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject designPanel;
    public GameObject levelPanel;

    void Start()
    {
        // Optionally, you can set the initial panel to be active
        ShowStartPanel(); // Or whichever panel you want to be the default
    }

    public void ShowStartPanel()
    {
        if (startPanel != null && designPanel != null && levelPanel != null)
        {
            startPanel.SetActive(true);
            designPanel.SetActive(false);
            levelPanel.SetActive(false);
            // Debug.Log("ShowStartPanel: Start panel activated, Design and Level panels deactivated.");
        }
    }

    public void ShowDesignPanel()
    {
        if (designPanel != null && startPanel != null && levelPanel != null)
        {
            designPanel.SetActive(true);
            startPanel.SetActive(false);
            levelPanel.SetActive(false);
            // Debug.Log("ShowDesignPanel: Design panel activated, Start and Level panels deactivated.");
        }
    }

    public void ShowLevelPanel()
    {
        if (levelPanel != null && startPanel != null && designPanel != null)
        {
            levelPanel.SetActive(true);
            startPanel.SetActive(false);
            designPanel.SetActive(false);
            // Debug.Log("ShowLevelPanel: Level panel activated, Start and Design panels deactivated.");
        }
    }
}
