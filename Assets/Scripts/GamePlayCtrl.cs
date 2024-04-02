using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;

public class GamePlayCtrl : MonoBehaviour
{
    public static GamePlayCtrl instance;
    [SerializeField]
    private Button Intruction;
    [SerializeField]
    private Text scoreText, endScoreText, bestScoreText;
    public GameObject gameOverPanel;
    public GameObject pausePanel;




    private void Awake()
    {
        Time.timeScale = 0;
        GamePlayCtrl.instance = this;
    }
    public void _IntructionButton()
    {
        Time.timeScale = 1;
        Intruction.gameObject.SetActive(false); //Do Intruction Button là Button nên thêm gameobject
    }
    public void setScore(int score)
    {
        scoreText.text = "" + score;
    }
    public void birdDieShowPanel(int score)
    {
        gameOverPanel.SetActive(true);
        endScoreText.text = "" + score;

        // Check if GameManager.instance is not null before using it
        if (GameManager.instance != null)
        {
            if (score > GameManager.instance.getHighScore())
            {
                GameManager.instance.setHighScore(score);
            }
            bestScoreText.text = "" + GameManager.instance.getHighScore();
        }
    }
    public void menuButton()
    {
        SceneManager.LoadScene("GameMenu");
    }
    public void restarButton()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void pauseButton()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }
    public void pausePanelButton()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
}