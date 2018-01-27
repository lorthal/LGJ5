using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransmitterController : MonoBehaviour
{
    public float packages;
    public float packegesSendPerSecond;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && ReciverManager.Instance.GameState == ReciverManager.LevelState.Running)
        {
            if (packages > 0)
            {
                float sendedPackages = packages - packegesSendPerSecond * Time.fixedDeltaTime >= 0 ? packegesSendPerSecond * Time.fixedDeltaTime : packages;

                ReciverManager.Instance.SendPackage(sendedPackages);
                packages -= sendedPackages;
            }
        }
    }
}
