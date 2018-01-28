using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonClick : MonoBehaviour
{
    public string SceneName;

    public GameObject Levels;

    private bool isMovingLeft, isMovingRight;

    private Vector3 target;

    public void OnPlayLevelClick()
    {
        SceneManager.LoadScene(SceneName);
    }

    private void Update()
    {
        if (isMovingLeft)
        {
            Levels.GetComponent<RectTransform>().anchoredPosition = Vector3.MoveTowards(Levels.GetComponent<RectTransform>().anchoredPosition, target, 5000 * Time.deltaTime);
            if (Levels.GetComponent<RectTransform>().anchoredPosition.x <= target.x)
            {
                isMovingLeft = false;
                Levels.GetComponent<RectTransform>().anchoredPosition = target;
            }
        }

        if (isMovingRight)
        {
            Levels.GetComponent<RectTransform>().anchoredPosition = Vector3.MoveTowards(Levels.GetComponent<RectTransform>().anchoredPosition, target, 5000 * Time.deltaTime);
            if (Levels.GetComponent<RectTransform>().anchoredPosition.x >= target.x)
            {
                isMovingRight = false;
                Levels.GetComponent<RectTransform>().anchoredPosition = target;
            }
        }
    }

    public void OnPlayClick()
    {
        if (!isMovingRight)
        {
            isMovingLeft = true;
            target = new Vector3(-1920, 0, 0);
        }
    }

    public void OnMenuBackClick()
    {
        if (!isMovingRight)
        {
            isMovingRight = true;
            target = new Vector3(0, 0, 0);
        }
    }

    public void OnNextLevelClick()
    {
        string[] sceneNameSplited = SceneManager.GetActiveScene().name.Split('_');
        int lvlNumber = int.Parse(sceneNameSplited[1]);

        lvlNumber++;

        string sceneName = sceneNameSplited[0] + "_" + lvlNumber;

        if (Application.CanStreamedLevelBeLoaded(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            SceneManager.LoadScene("menu");
        }
    }
}
