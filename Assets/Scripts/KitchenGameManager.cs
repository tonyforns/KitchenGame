using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenGameManager : MonoBehaviour
{

    public static KitchenGameManager Instance { get; private set; }

    public event EventHandler OnStateChange;
    public event EventHandler OnGamePaused;
    public event EventHandler OnGameUnpaused;
    private enum State
    {
        WaitingToStart,
        CountDownToStart,
        GamePlaying,
        GameOver
    }

    private State state;
    private float waitingToStartTimer = 1f;
    private float countDownToStartTimer = 3f;
    private float gamePlayingTimer;
    private float gamePlayingTimerMax = 10f;
    private bool isPause = false;

    private void Awake()
    {
        Instance = this;
        GameInput.Instance.OnPauseAction += GameInput_OnPauseAction;
        state = State.WaitingToStart;
    }

    private void GameInput_OnPauseAction(object sender, EventArgs e)
    {
        TogglePauseGame();
    }

   
    private void Update()
    {
        switch (state)
        {
            case State.WaitingToStart:
                waitingToStartTimer -= Time.deltaTime;
                if(waitingToStartTimer < 0)
                {
                    state = State.CountDownToStart;
                    OnStateChange?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.CountDownToStart:
                countDownToStartTimer -= Time.deltaTime;
                if (countDownToStartTimer < 0)
                {
                    gamePlayingTimer = gamePlayingTimerMax;
                    state = State.GamePlaying;
                    OnStateChange?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.GamePlaying:
                gamePlayingTimer -= Time.deltaTime;
                if (gamePlayingTimer < 0)
                {
                    state = State.GameOver;
                    OnStateChange?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.GameOver:
                break;
        }
    }

    public bool IsGamePlaying()
    {
        return state == State.GamePlaying;
    }

    public bool IsCountdownToStartActive()
    {
        return state == State.CountDownToStart;
    }

    public bool IsGameOver() 
    {
        return state == State.GameOver;
    }

    public float GetCountdownToStartTimer()
    {
        return countDownToStartTimer;
    }

    public float GetGamePlayingTimerNormalized()
    {
        return  1 - gamePlayingTimer / gamePlayingTimerMax;
    }

    public void TogglePauseGame()
    {
        isPause = !isPause;
        if(isPause)
        {
            Time.timeScale = 0;
            OnGamePaused?.Invoke(this, EventArgs.Empty);
        } else
        {
            Time.timeScale = 1;
            OnGameUnpaused?.Invoke(this, EventArgs.Empty);

        }
    }

}
