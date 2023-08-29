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
        //skin ����.
        GUI.skin = mySkin;
        Rect labelRect1 = new Rect(10.0f, 10.0f, 400.0f, 100.0f);   //��ġ x, ��ġy, ��, ����
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
            {   //��� ���� ����
                Awake();
                //Time.timeScale=0f�̸� ���߰�, 0.5f�� 0.5���, 1f�� 1������� ������ �����.
                Time.timeScale = 1f;
            }
        }
    }
}
