using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReciverManager : MonoBehaviour
{
    public static ReciverManager Instance { get; private set; }

    private Message msg;

    public int requiredPackages;

    private int currentPackeges;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}
