using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReciverManager : MonoBehaviour
{
    public static ReciverManager Instance { get; private set; }

    private Message msg;

    public float requiredPackages;

    private float currentPackeges;

    public bool levelCompleted { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            levelCompleted = false;
        }
    }

    public void SendPackage(float packages)
    {
        if (!levelCompleted)
        {
            if (currentPackeges < requiredPackages)
            {
                currentPackeges += packages;
            }
            
            if(currentPackeges >= requiredPackages)
            {
                levelCompleted = true;
            }
            Debug.Log(currentPackeges + "/" + requiredPackages + ", Level completed: " + levelCompleted);
        }
    }
}
