using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConfirmPannel : MonoBehaviour
{
    [Header("Level information")]
    public string levelToLoad;
    public int level;
    private GameData gameData;
    private int starsActive;
    private int highScore;

    [Header("UI Stuff")]
    public Image[] stars;
    public Text highScoreText;
    public Text starText;

    public GameObject[] otherPanels;

    public int Level { get => level; set => level = value; }

    // Start is called before the first frame update
    void OnEnable()
    {
        gameData = FindObjectOfType<GameData>();
        LoadData();
        ActivateStars();
        SetText();
        DisableOtherPanels();
    }

    void LoadData()
    {
        if (gameData != null)
        {
            starsActive = gameData.saveData.stars[level - 1];
            highScore = gameData.saveData.highScore[level - 1];
        }
    }

    void SetText()
    {
        highScoreText.text = "" + highScore;
        starText.text = "" + starsActive + "/3";
    }

    void ActivateStars()
    {
        for (int i = 0; i < starsActive; i++)
        {
            stars[i].enabled = true;
        }
    }

    void DisableOtherPanels()
    {
        foreach (GameObject panel in otherPanels)
        {
            panel.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Cancel()
    {
        this.gameObject.SetActive(false);
    }

    public void Play()
    {
        PlayerPrefs.SetInt("Current Level", level - 1);
        string scene;
        Debug.Log("Level = " + level);
        if (level < 4)
        {
            scene = "Main";
            Debug.Log("Tetris");
        }
        else if (level < 6)
        {
            scene = "Main 1";
            Debug.Log("Bejeweled");
        }
        else
        {
            scene = "Main 2";
            Debug.Log("Candy");
        }
        SceneManager.LoadScene(scene);
    }
}
