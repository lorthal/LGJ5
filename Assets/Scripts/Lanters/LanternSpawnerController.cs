using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LanternSpawnerController : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (ReciverManager.Instance.GameState == ReciverManager.LevelState.Running)
        {
            LanternsManager.Instance.SpawnLantern(eventData.pointerPressRaycast.worldPosition);
        }
    }
}
