using HighlightingSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    public static GameManger Instance;
    public Transform PlayerFPS;
    public Transform Tip;
    public Transform ScorePanel;
    public Transform EventTrigger;
    public Transform Task;
    public GameObject Toilet;
    public Transform EndPanel;
    public string[] strs;
    public Highlighter[] HighOBJ;
    public GameObject[] gos;

    int currentScore = 0;
    private void Start()
    {
        Instance = this;
        ShowTip(-1);  //Init
        ShowTigger(-1);  //Init
    }
    void Update()
    {
        ScorePanel.GetChild(0).GetComponent<Text>().text = currentScore.ToString();

        if (Input.anyKeyDown)
        {
            PlayerFPS.GetComponent<PlayerMove>().enabled = true;
            PlayerFPS.GetChild(0).GetComponent<PlayerLook>().enabled = true;
        }
    }
    public void showgos(int value)
    {
        for (int i = 0; i < 3; i++)
        {
            gos[i].SetActive(false);
        }
        gos[value].SetActive(true);
    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void ExitGame()
    {
#if UNITY_EDITOR  

        UnityEditor.EditorApplication.isPlaying = false;
#else
                            Application.Quit();
#endif

    }
    public void ShowEndPanel()
    {
        Tip.gameObject.SetActive(false);
        ScorePanel.gameObject.SetActive(false);

        EndPanel.gameObject.SetActive(true);
        int realTimeScore = 30000 - currentScore * 100;
        if (realTimeScore > 10000)
            EndPanel.GetChild(0).GetComponent<Text>().text = "Excellent";
        else if (realTimeScore > 0 && realTimeScore < 10000)
            EndPanel.GetChild(0).GetComponent<Text>().text = "Pass";
        else if (realTimeScore < 0)
            EndPanel.GetChild(0).GetComponent<Text>().text = "Fail";

        EndPanel.GetChild(1).GetComponent<Text>().text = realTimeScore.ToString();
        Time.timeScale = 0;
    }
    public void Enter_Toilet()
    {
        //Toilet.SetActive(true);
        Task.GetChild(10).gameObject.SetActive(true);
    }
    /// <summary>
    /// show tip
    /// </summary>
    /// <param name="value"></param>
    public void ShowTip(int value)
    {
        if (value == -1)
        {
            Tip.GetChild(0).GetComponent<Text>().text = "";
            Tip.gameObject.SetActive(false);
            return;
        }
        Tip.gameObject.SetActive(true);
        Tip.GetChild(0).GetComponent<Text>().text = strs[value];
    }
    public void ShowTigger(int value)
    {
        for (int i = 0; i < 9; i++)
        {
            EventTrigger.GetChild(i).gameObject.SetActive(false);
        }
        if (value == -1)
            return;
        EventTrigger.GetChild(value).gameObject.SetActive(true);
    }
    public void ShowTask(int value)
    {
        for (int i = 0; i < 9; i++)
        {
            Task.GetChild(i).gameObject.SetActive(false);
        }
        if (value == -1)
            return;
        Task.GetChild(value).gameObject.SetActive(true);
        HighOBJ[value].enabled = true;
    }
    public void ShowToiletHigh()
    {
        HighOBJ[9].enabled = true;
    }
    public void InitHighOBJ()
    {
        for (int i = 0; i < HighOBJ.Length; i++)
        {
            HighOBJ[i].enabled = false;
        }
    }
    public void AddScore(int value)
    {
        currentScore += value;
    }
}
