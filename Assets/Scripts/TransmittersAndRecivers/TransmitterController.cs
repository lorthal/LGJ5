using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransmitterController : MonoBehaviour
{
    public float packages;
    public float packegesSendPerSecond;
    private float timer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            timer = 0;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !ReciverManager.Instance.levelCompleted)
        {
            if (packages > 0)
            {
                float sendedPackages = packages - packegesSendPerSecond * Time.fixedDeltaTime >= 0 ? packegesSendPerSecond * Time.fixedDeltaTime : packages;

                ReciverManager.Instance.SendPackage(sendedPackages);
                packages -= sendedPackages;
                timer = 0;
            }

        }
    }
}
