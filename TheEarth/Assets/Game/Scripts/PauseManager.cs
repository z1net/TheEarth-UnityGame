﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private Text buildText;

    public static GameState CurrentGameState { get; private set; } = GameState.Play;



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            bool allow = true;
            if (CurrentGameState == GameState.Pause)
            {
                OnPauseSetRequested?.Invoke(ref allow);

                if (!allow) { return; }

                Time.timeScale = 1;
                CurrentGameState = GameState.Play;

                showBuildVersion(false);
                OnPauseUnsetted?.Invoke();
                return;
            }

            OnPauseUnsetRequested?.Invoke(ref allow);

            if (!allow) { return; }

            Time.timeScale = 0;

            CurrentGameState = GameState.Pause;

            showBuildVersion(true);

            OnPauseSetted?.Invoke();
        }
    }

    private void showBuildVersion(bool active = true)
    {
        buildText.gameObject.SetActive(active);

        buildText.text = "Build: " + Application.version;
    }

    public static bool IsGamePaused()
    {
        return CurrentGameState == GameState.Pause;
    }

    public enum GameState
    {
        Play,
        Pause
    }



    public delegate void PauseHandler(ref bool allow);
    public delegate void PauseUnsetHadnler(ref bool allow);
    public delegate void PauseSetHandler();
    public delegate void PauseUnsettedHandler();



    public static event PauseHandler OnPauseSetRequested;
    public static event PauseUnsetHadnler OnPauseUnsetRequested;
    public static event PauseSetHandler OnPauseSetted;
    public static event PauseUnsettedHandler OnPauseUnsetted;
}
