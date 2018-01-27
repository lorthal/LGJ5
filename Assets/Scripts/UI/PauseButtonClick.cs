using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonClick : MonoBehaviour
{

    public GameObject PauseMenu;

    public void OnPauseButtonClick()
    {
        if (ReciverManager.Instance.GameState == ReciverManager.LevelState.Running)
        {
            ReciverManager.Instance.GameState = ReciverManager.LevelState.Paused;
            PauseMenu.SetActive(true);
        }    
    }

    public void OnResumeButtonClick()
    {
        if (ReciverManager.Instance.GameState == ReciverManager.LevelState.Paused)
        {
            ReciverManager.Instance.GameState = ReciverManager.LevelState.Running;
            PauseMenu.SetActive(false);
        }
    }
}
