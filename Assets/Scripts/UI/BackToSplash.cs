using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToSplash : MonoBehaviour
{
    public string sceneToLoad;
    private GameData gameData;
    private Board board;
    private bool loadLevelSelect = false;

    public void WinOK()
    {
        if (gameData != null)
        {
            gameData.saveData.isActive[board.level + 1] = true;
            gameData.Save();
        }

        loadLevelSelect = true;
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(sceneToLoad);
    }

    public void LoseOK()
    {
        loadLevelSelect = true;
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(sceneToLoad);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (loadLevelSelect)
        {
            Debug.Log("OnSceneLoaded: Scene " + scene.name + " loaded.");

            GameObject levelPanel = GameObject.FindWithTag("Level Select");
            if (levelPanel != null)
            {
                Debug.Log("OnSceneLoaded: Activating LevelSelect panel");
                levelPanel.SetActive(true);
            }
            else
            {
                Debug.LogError("OnSceneLoaded: LevelSelect panel not found");
            }

            GameObject startPanel = GameObject.FindWithTag("Start");
            if (startPanel != null)
            {
                Debug.Log("OnSceneLoaded: Deactivating Start panel");
                startPanel.SetActive(false);
            }

            loadLevelSelect = false;
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

    void Start()
    {
        gameData = FindObjectOfType<GameData>();
        board = FindObjectOfType<Board>();
    }

    void Update()
    {

    }
}
