using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Ready,
        Start,
        Playing,
        GameOver
    }

    // Start is called before the first frame update
    public static GameManager Instance;
    public GameState m_state = GameState.Ready;
    public GameObject menuCam;
    public GameObject gameCam;
    public TextMeshProUGUI userName;
    public int floor;
    public int box;

    public GameObject menuPanel;
    public GameObject gamePanel;
    public GameObject nextPanel;
    public GameObject failPanel;
    public GameObject gameoverPanel;

    private void Awake()
    {
        Instance = this;
    }

    // 메뉴카메라, 게임카메라 설정
    public void GameStart()
    {
        m_state = GameState.Start;

        menuCam.SetActive(false);
        gameCam.SetActive(true);

        menuPanel.SetActive(false);
        gamePanel.SetActive(true);

        //player.gameObject.SetActive(true);
    }

    public void OnClickRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Grass()
    {
        PlayerPrefs.SetInt("Life", NK_Life.LifeManager.Life);
        SceneManager.LoadScene("PlayScene2");
    }
    public void Road()
    {
        PlayerPrefs.SetInt("Life", NK_Life.LifeManager.Life);
        SceneManager.LoadScene("PlayScene3");
    }
    public void End()
    {
        int currentScore = PlayerPrefs.GetInt("Score");
        int topScore = PlayerPrefs.GetInt("TopScore");
        if (currentScore > topScore)
        {
            PlayerPrefs.SetInt("TopScore", currentScore);
        }
        SceneManager.LoadScene("ScoreScene");
    }
    public void Replay()
    {
        PlayerPrefs.SetInt("Life", 3);
        PlayerPrefs.SetInt("Score", 0);
        SceneManager.LoadScene("StartScene");
    }

    public void Go()
    {
        PlayerPrefs.SetString("CurrentUserName", userName.text);
        PlayerPrefs.SetInt("Life", 3);
        PlayerPrefs.SetInt("Score", 0);
        SceneManager.LoadScene("PlayScene1");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayerPrefs.SetInt("Life", 3);
            PlayerPrefs.SetInt("Score", 0);
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            End();
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            GameObject.Find("Player").transform.position = new Vector3(-13.64f, -3.7f, 193f);
        }

        if (Input.GetKeyDown(KeyCode.F3))
        {
            GameObject.Find("Player").transform.position = new Vector3(-13.64f, 22.26f, 184.8f);
        }

        switch(m_state)
        {
            case GameState.Ready:
                ReadyState();
                break;
            case GameState.Start:
                StartState();
                break;
            case GameState.Playing:
                PlayingState();
                break;
            case GameState.GameOver:
                GameOverState();
                break;
        }
    }

    private void ReadyState()
    {

    }

    private void StartState()
    {
        m_state = GameState.Playing;
    }

    private void PlayingState()
    {

    }

    private void GameOverState()
    {
        m_state = GameState.Ready;
    }
}






