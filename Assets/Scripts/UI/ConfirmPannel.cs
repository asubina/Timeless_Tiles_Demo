using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConfirmPannel : MonoBehaviour
{
    public string levelToLoad;
    public Image[] stars;
    private int starsActive;
    public int level;
    public int Level { get => level; set => level = value; }
    private GameData gameData;

    // Start is called before the first frame update
    void Start()
    {
        gameData = FindObjectOfType<GameData>();
        ActivateStars();
    }

    void LoadData()
    {
        if(gameData != null)
        {
            starsActive = gameData.saveData.stars[level - 1];
        }
    }
    void ActivateStars()
    {
        //COME BACK
        for (int i = 0; i < starsActive; i++)
        {
            stars[i].enabled = true;
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
        PlayerPrefs.SetInt("Current Level", level -1);
        SceneManager.LoadScene(levelToLoad);
    }
}
