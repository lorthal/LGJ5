using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanternUIController : MonoBehaviour
{

    public Text lanternCount;
	void Update ()
	{
	    lanternCount.text = "" + (LanternsManager.Instance.maxLanternCount - LanternsManager.Instance.lanters.Count);
	}
}
