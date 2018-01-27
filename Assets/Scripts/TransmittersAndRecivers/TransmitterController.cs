using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransmitterController : MonoBehaviour
{
    public float packages;
    public float packegesSendPerSecond;

    public Vector2 DistanceMultiplierRange;

    private SphereCollider sphere;

    private void Start()
    {
        sphere = GetComponent<SphereCollider>();
    }

    private float GetDistanceMultiplier(Vector3 position)
    {
        float distance = Vector3.Distance(transform.position, position);

        float distanceToRadiusRatio = distance / sphere.radius;

        if (distanceToRadiusRatio < DistanceMultiplierRange.x)
        {
            distanceToRadiusRatio = DistanceMultiplierRange.x;
        }

        if (distanceToRadiusRatio > DistanceMultiplierRange.y)
        {
            distanceToRadiusRatio = 1.0f;
        }

        return distanceToRadiusRatio;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && ReciverManager.Instance.GameState == ReciverManager.LevelState.Running)
        {
            if (packages > 0)
            {
                float packegesPerFrame = packegesSendPerSecond * Time.fixedDeltaTime *
                                         GetDistanceMultiplier(other.gameObject.transform.position);
                float sendedPackages = packages - packegesPerFrame  >= 0 ? packegesPerFrame : packages;

                Debug.Log("Sended packages: " + sendedPackages);

                ReciverManager.Instance.SendPackage(sendedPackages);
                packages -= sendedPackages;
            }
        }
    }
}
