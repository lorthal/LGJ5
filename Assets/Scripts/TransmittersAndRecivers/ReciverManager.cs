using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReciverManager : MonoBehaviour
{
    public enum LevelState
    {
        Running,
        Paused,
        Won,
        Lost
    }

    public static ReciverManager Instance { get; private set; }

    public float TimeToCompleteInSeconds;
    [Range(0, 1)] public float Star3Percent;
    [Range(0, 1)] public float Star2Percent;

    public MessageList msgList;

    public GameObject GameOver, WinGame;

    public float requiredPackages;

    public float EndgameTime;

    public AudioClip Lose, Win;

    private float currentPackeges;

    private float timer, endGameTimer;

    private LevelState gameState;

    public Message Msg { get; private set; }

    public int StarRecived { get; private set; }

    public LevelState GameState
    {
        get { return gameState; }
        set
        {
            if (gameState != LevelState.Lost && gameState != LevelState.Won)
            {
                gameState = value;
                if (value == LevelState.Paused)
                {
                    Time.timeScale = 0;
                }
                else
                {
                    Time.timeScale = 1;
                }
            }

            if (value == LevelState.Lost)
            {
                if (GetComponent<AudioSource>() != null)
                {
                    GetComponent<AudioSource>().clip = Lose;
                    GetComponent<AudioSource>().Play();
                }
              
                endGameTimer = 0;
            }

            if (value == LevelState.Won)
            {
                if (GetComponent<AudioSource>() != null)
                {
                    GetComponent<AudioSource>().clip = Win;
                    GetComponent<AudioSource>().Play();
                }
                WinGame.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            GameState = LevelState.Running;
        }
        Time.timeScale = 1.0f;
    }

    private void Start()
    {
        timer = TimeToCompleteInSeconds;
        StarRecived = 3;
        Msg = msgList.GetMessage();
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if ((timer / TimeToCompleteInSeconds) < Star3Percent && StarRecived == 3)
        {
            StarRecived--;
        }

        if ((timer / TimeToCompleteInSeconds) < Star2Percent && StarRecived == 2)
        {
            StarRecived--;
        }

        if (timer <= 0)
        {
            GameState = LevelState.Lost;
        }

        if (GameState == LevelState.Lost)
        {
            if (endGameTimer >= EndgameTime)
            {
                GameOver.SetActive(true);
                Time.timeScale = 0;
            }
            endGameTimer += Time.deltaTime;
        }
    }

    public float GetTimePercentage()
    {
        return timer / TimeToCompleteInSeconds;
    }

    public float GetCompletionPercentage()
    {
        return currentPackeges / requiredPackages;
    }

    public void SendPackage(float packages)
    {
        if (GameState == LevelState.Running)
        {
            if (currentPackeges < requiredPackages)
            {
                currentPackeges += packages;
            }

            if (currentPackeges >= requiredPackages)
            {
                GameState = LevelState.Won;
            }
        }
    }

    private void OnDestroy()
    {
        Instance = null;
    }
}
