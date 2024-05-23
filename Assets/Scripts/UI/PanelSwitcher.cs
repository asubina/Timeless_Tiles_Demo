using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSwitcher : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject designPanel;
    public GameObject rulesPanel;
    public GameObject levelPanel;

    void Start()
    {
        // Optionally, you can set the initial panel to be active
        ShowStartPanel(); // Or whichever panel you want to be the default
    }

    public void ShowStartPanel()
    {
        if (startPanel != null && designPanel != null && levelPanel != null && rulesPanel != null)
        {
            startPanel.SetActive(true);
            designPanel.SetActive(false);
            levelPanel.SetActive(false);
            rulesPanel.SetActive(false);
            // Debug.Log("ShowStartPanel: Start panel activated, Design and Level panels deactivated.");
        }
    }

    public void ShowDesignPanel()
    {
        if (designPanel != null && startPanel != null && levelPanel != null && rulesPanel != null)
        {
            designPanel.SetActive(true);
            startPanel.SetActive(false);
            levelPanel.SetActive(false);
            rulesPanel.SetActive(false);
            // Debug.Log("ShowDesignPanel: Design panel activated, Start and Level panels deactivated.");
        }
    }

    public void ShowLevelPanel()
    {
        if (levelPanel != null && startPanel != null && designPanel != null && rulesPanel != null)
        {
            levelPanel.SetActive(true);
            startPanel.SetActive(false);
            designPanel.SetActive(false);
            rulesPanel.SetActive (false);
            // Debug.Log("ShowLevelPanel: Level panel activated, Start and Design panels deactivated.");
        }
    }

    public void ShowRulesPanel()
    {
        if(startPanel != null && designPanel != null && levelPanel != null && rulesPanel != null)
        {
            rulesPanel.SetActive(true);
            startPanel.SetActive(false);
            designPanel.SetActive(false);
            levelPanel.SetActive(false);

        }
    }
}
