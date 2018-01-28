using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinGameUIController : MonoBehaviour
{

    public Image Star3, Star2;

    public Text MessageText;

    public Sprite LostStarSprite;

    private void Start()
    {
        if (ReciverManager.Instance.StarRecived == 2)
        {
            Star3.GetComponentInChildren<Image>().sprite = LostStarSprite;
        }

        if (ReciverManager.Instance.StarRecived == 1)
        {
            Star2.GetComponentInChildren<Image>().sprite = LostStarSprite;
            Star3.GetComponentInChildren<Image>().sprite = LostStarSprite;
        }
        MessageText.text = ReciverManager.Instance.Msg.GetMessage();
    }
}
