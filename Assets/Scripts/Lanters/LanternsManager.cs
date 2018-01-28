using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class LanternsManager : MonoBehaviour
{
    public int maxLanternCount = 3;
    public float cooldownOnChangeLantern;

    public static LanternsManager Instance { get; private set; }

    public List<Lantern> lanters;

    public GameObject lanternPrefab;

    private Lantern lightedLantern;
    private float cooldownTimer;
    private bool canChange;

    public AudioClip CreateLatern;
    public AudioClip LanternNotAlowed;

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

    public void SpawnLantern(Vector3 position)
    {
        if (lanters.Count < maxLanternCount)
        {
            GameObject spawned = Instantiate(lanternPrefab, position, Quaternion.identity);
            spawned.transform.parent = transform;
            GetComponent<AudioSource>().clip = CreateLatern;
            GetComponent<AudioSource>().Play();
        }
        else
        {
            GetComponent<AudioSource>().clip = LanternNotAlowed;
            GetComponent<AudioSource>().Play();
        }
    }

    private void OnDestroy()
    {
        Instance = null;
    }
}
