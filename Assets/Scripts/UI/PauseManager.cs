using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.Experimental.GraphView;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;
    private Board board;
    public bool paused = false;
    public Image soundButton;
    public Sprite musicOnSprite;
    public Sprite musicOffSprite;
    private SoundManager sound; 

    // Start is called before the first frame update
    void Start()
    {
        sound = FindObjectOfType<SoundManager>();
        board = GameObject.FindWithTag("Board").GetComponent<Board>();
        pausePanel.SetActive(false);
        if (PlayerPrefs.HasKey("Sound")){
            if(PlayerPrefs.GetInt("Sound") == 0)
            {
                soundButton.sprite = musicOffSprite;
            }
            else
            {
                soundButton.sprite = musicOnSprite;
            }
        }
        else
        {
            soundButton.sprite = musicOnSprite;
        }
    }

    public void SoundButton()
    {
        if (PlayerPrefs.HasKey("Sound"))
        {
            if (PlayerPrefs.GetInt("Sound") == 0)
            {
                PlayerPrefs.SetInt("Sound", 1);
                soundButton.sprite = musicOnSprite;
                sound.AdjustVolume();
            }
            else
            {
                PlayerPrefs.SetInt("Sound", 0);
                soundButton.sprite = musicOffSprite;
                sound.AdjustVolume();
            }
        }
        else
        {
            PlayerPrefs.SetInt("Sound", 0);
            soundButton.sprite = musicOffSprite;
            sound.AdjustVolume();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(paused && !pausePanel.activeInHierarchy)
        {
            pausePanel.SetActive(true);
            board.currentState = GameState.pause;
        }
        if(!paused && pausePanel.activeInHierarchy)
        {
            pausePanel.SetActive(false);
            board.currentState = GameState.move;
        }
    }

    public void PauseGame()
    {
        paused = !paused;
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("Splash");
    }
}
