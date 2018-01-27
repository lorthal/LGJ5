using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Lantern : MonoBehaviour, IPointerClickHandler
{
    public float lightCooldown;

    private bool lightOn;
    public Light[] lights;

    private float cooldownTimer;

    void Start()
    {
        LanternsManager.Instance.lanters.Add(this);
        cooldownTimer = 0;
        LanternsManager.Instance.SetLightedLantern(this);
    }

    private void Update()
    {
        if (lightOn && cooldownTimer >= 0.5f)
        {
            if (cooldownTimer < lightCooldown)
            {
                cooldownTimer += Time.deltaTime;
            }
            else
            {
                SetLightOn(false);
                ShipController.Instance.ChangeDestination(null);
            }
        }
    }

    public void SetLightOn(bool isLighted)
    {
        lightOn = isLighted;

        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].enabled = lightOn;
        }

        if (lightOn)
        {
            ShipController.Instance.ChangeDestination(transform);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        LanternsManager.Instance.SetLightedLantern(this);
    }
}
