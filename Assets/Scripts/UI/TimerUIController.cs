using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUIController : MonoBehaviour
{

    public GameObject Pointer;
    public Image FillImage;


    private void Update()
    {
        Pointer.transform.localRotation = Quaternion.AngleAxis(-360.0f * (1 - ReciverManager.Instance.GetTimePercentage()), Vector3.forward);
        FillImage.fillAmount = ReciverManager.Instance.GetTimePercentage();
    }
}
