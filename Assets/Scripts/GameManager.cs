using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private const string HIGH_SCORE = "high score";
    private void Awake()
    {
        loadSingleGameManager();
        isStartedTheFirstGame();
    }
    void isStartedTheFirstGame()
    {
        if(!PlayerPrefs.HasKey("isStartedTheFirstGame")) //Tr? v? true
        {
            PlayerPrefs.SetInt("high score", 0); //cho ban ??u = 0;
            PlayerPrefs.SetInt("isStartedTheFirstGame", 0); // ??a l?i b?ng false;

        }
    }
    public void loadSingleGameManager()
    {
        if(instance!=null)
            Destroy(gameObject); 
        else
        {
            instance = this; //không b? h?y 
            DontDestroyOnLoad(gameObject);

        }
    }
    public void setHighScore(int score)
    {
        PlayerPrefs.SetInt(HIGH_SCORE, score);
    }
    public int getHighScore()
    {
        return PlayerPrefs.GetInt(HIGH_SCORE);
    }
}