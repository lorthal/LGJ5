using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUIController : MonoBehaviour
{

    public GameObject Pointer;
    public Image FillImage;

    public GameObject Star3;
    public GameObject Star2;

    public Sprite LostStarSprite;

    private void Start()
    {
        Star3.transform.localRotation = Quaternion.AngleAxis(-360.0f * (1 - ReciverManager.Instance.Star3Percent), Vector3.forward);
        Star2.transform.localRotation = Quaternion.AngleAxis(-360.0f * (1 - ReciverManager.Instance.Star2Percent), Vector3.forward);
    }

    private void Update()
    {
        Pointer.transform.localRotation = Quaternion.AngleAxis(-360.0f * (1 - ReciverManager.Instance.GetTimePercentage()), Vector3.forward);
        FillImage.fillAmount = ReciverManager.Instance.GetTimePercentage();

        if (ReciverManager.Instance.StarRecived == 2)
        {
            Star3.GetComponentInChildren<Image>().sprite = LostStarSprite;
        }

        if (ReciverManager.Instance.StarRecived == 1)
        {
            Star2.GetComponentInChildren<Image>().sprite = LostStarSprite;
        }
    }
}
