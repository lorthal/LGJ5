using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class LanternsManager : MonoBehaviour
{

    public float cooldownOnChangeLantern;

    public static LanternsManager Instance { get; private set; }

    public List<Lantern> lanters;

    private Lantern lightedLantern;
    private float cooldownTimer;
    private bool canChange;

    private void Awake()
    {
        lanters = new List<Lantern>();
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if (cooldownTimer < cooldownOnChangeLantern)
        {
            cooldownTimer += Time.deltaTime;
        }
        else if(!canChange)
        {
            canChange = true;
        }
    }

    public void SetLightedLantern(Lantern lantern)
    {
        if (canChange)
        {
            lightedLantern = lantern;

            foreach (var item in lanters)
            {
                if (!item.Equals(lightedLantern))
                {
                    item.SetLightOn(false);
                }
            }
            lightedLantern.SetLightOn(true);
            canChange = false;
            cooldownTimer = 0;
        }
    }
}
