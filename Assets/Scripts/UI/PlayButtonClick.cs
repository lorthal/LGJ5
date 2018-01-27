using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonClick : MonoBehaviour
{
    public Scene scene;

    public void OnPlayClick()
    {
        SceneManager.LoadScene(scene.name);
    }
}
