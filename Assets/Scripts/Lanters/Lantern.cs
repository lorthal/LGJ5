using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    public float lightCooldown;

    private bool lightOn;
    public Light[] lights;

    private float cooldownTimer;

    void Start()
    {
        LanternsManager.Instance.lanters.Add(this);
        cooldownTimer = 0;
    }

    private void Update()
    {
        if (lightOn)
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
}
