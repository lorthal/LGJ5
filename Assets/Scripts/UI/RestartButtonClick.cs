using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButtonClick : MonoBehaviour {

    public void OnRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
