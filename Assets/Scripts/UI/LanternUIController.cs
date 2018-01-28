using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanternUIController : MonoBehaviour
{

    public Sprite NoLanternImageSprite;

    public Text lanternCount;
	void Update ()
	{
	    lanternCount.text = "" + (LanternsManager.Instance.maxLanternCount - LanternsManager.Instance.lanters.Count);

	    if (LanternsManager.Instance.maxLanternCount - LanternsManager.Instance.lanters.Count == 0)
	    {
	        GetComponent<Image>().sprite = NoLanternImageSprite;
	    }
	}
}
