using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSwitcher : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject designPanel;
    public GameObject rulesPanel;
    public GameObject levelPanel1;
    public GameObject levelPanel2;
    public GameObject levelPanel3;
    public GameObject confirmPanel;

    private List<GameObject> panels;

    void Start()
    {
        // Initialize the list of panels
        panels = new List<GameObject> { startPanel, designPanel, rulesPanel, levelPanel1, levelPanel2, levelPanel3, confirmPanel };

        // Optionally, set the initial panel to be active
        ShowPanel(startPanel); // Or whichever panel you want to be the default
    }

    public void ShowPanel(GameObject panelToShow)
    {
        foreach (GameObject panel in panels)
        {
            if (panel != null)
            {
                panel.SetActive(panel == panelToShow);
            }
        }
    }

    // The methods below can be linked to the corresponding buttons
    public void ShowStartPanel()
    {
        ShowPanel(startPanel);
    }

    public void ShowDesignPanel()
    {
        ShowPanel(designPanel);
    }

    public void ShowRulesPanel()
    {
        ShowPanel(rulesPanel);
    }

    public void ShowLevelPanel1()
    {
        ShowPanel(levelPanel1);
    }

    public void ShowLevelPanel2()
    {
        ShowPanel(levelPanel2);
    }

    public void ShowLevelPanel3()
    {
        ShowPanel(levelPanel3);
    }
}