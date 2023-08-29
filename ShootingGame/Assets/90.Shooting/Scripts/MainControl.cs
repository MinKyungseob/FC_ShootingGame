using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainControl : MonoBehaviour
{
    static public int Score = 0;
    static public int Life = 3;
    public GUISkin mySkin = null;
    public bool isGameOver;
    [SerializeField] GameObject gameOverUI;

    private void Awake()
    {
        gameOverUI.SetActive(false);
        MainControl.Score = 0;
        MainControl.Life = 3;
    }
    private void OnGUI()
    {
        //skin 변경.
        GUI.skin = mySkin;
        Rect labelRect1 = new Rect(10.0f, 10.0f, 400.0f, 100.0f);   //위치 x, 위치y, 폭, 높이
        GUI.Label(labelRect1, "SCORE : " + MainControl.Score);
        Rect labelRect2 = new Rect(10.0f, 110.0f, 400.0f, 100.0f);
        GUI.Label(labelRect2, "Life : " + MainControl.Life);
    }

    // Update is called once per frame
    void Update()
    {
        if(MainControl.Score>500)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Victory");
        }        
        if(MainControl.Life<1)
        {
            GameOver();
            restart();
        }
    }
    void GameOver()
    {
        isGameOver = true;
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    void restart()
    {
        if (isGameOver == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {   //모든 내용 리셋
                Awake();
                //Time.timeScale=0f이면 멈추고, 0.5f면 0.5배속, 1f면 1배속으로 게임이 진행됨.
                Time.timeScale = 1f;
            }
        }
    }
}
