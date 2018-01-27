using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressbarUIController : MonoBehaviour
{
    public Image FillBar;
	void Update ()
	{
	    FillBar.fillAmount = ReciverManager.Instance.GetCompletionPercentage();
	}
}
