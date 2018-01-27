using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransmitterController : MonoBehaviour
{
    public float packages;
    public float packegesSendPerSecond;

    public ParticleSystem transmissionParticleSystem;

    public Vector2 DistanceMultiplierRange;

    private SphereCollider sphere;

    private ParticleSystem.Particle[] particles;
    private int particleCount;

    private void Start()
    {
        sphere = GetComponent<SphereCollider>();
        particleCount = transmissionParticleSystem.particleCount;
    }

    private void Update()
    {
        if (ReciverManager.Instance.GameState != ReciverManager.LevelState.Running && transmissionParticleSystem.isPlaying)
        {
            transmissionParticleSystem.Stop();
        }
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && ReciverManager.Instance.GameState ==
            ReciverManager.LevelState.Running)
        {
            if (packages > 0 && !transmissionParticleSystem.isPlaying)
            {
                transmissionParticleSystem.Play();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && ReciverManager.Instance.GameState ==
            ReciverManager.LevelState.Running)
        {
            if (transmissionParticleSystem.isPlaying)
            {
                transmissionParticleSystem.Stop();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && ReciverManager.Instance.GameState == ReciverManager.LevelState.Running)
        {
            if (packages > 0)
            {
                Vector3 targetPosition = other.gameObject.GetComponent<ShipController>().Reciver.position;
                float packegesPerFrame = packegesSendPerSecond * Time.fixedDeltaTime *
                                         GetDistanceMultiplier(other.gameObject.transform.position);
                float sendedPackages = packages - packegesPerFrame >= 0 ? packegesPerFrame : packages;

                ParticleSystem.Particle[] particles =
                    new ParticleSystem.Particle[transmissionParticleSystem.particleCount];

                transmissionParticleSystem.GetParticles(particles);

                for (int i = 0; i < particles.Length; i++)
                {
                    ParticleSystem.Particle p = particles[i];
                    p.rotation = Vector3.Angle(transmissionParticleSystem.transform.forward,
                        targetPosition - transmissionParticleSystem.transform.position);
                    p.position = Vector3.Lerp(transmissionParticleSystem.transform.position, targetPosition, 1 - (p.remainingLifetime/p.startLifetime));

                    particles[i] = p;
                }

                transmissionParticleSystem.SetParticles(particles, particles.Length);

                ReciverManager.Instance.SendPackage(sendedPackages);
                packages -= sendedPackages;
            }
            else
            {
                if (transmissionParticleSystem.isPlaying)
                {
                    transmissionParticleSystem.Stop();
                }
            }
        }

        if (ReciverManager.Instance.GameState == ReciverManager.LevelState.Won ||
            ReciverManager.Instance.GameState == ReciverManager.LevelState.Lost)
        {
            if (transmissionParticleSystem.isPlaying)
            {
                transmissionParticleSystem.Stop();
            }
        }
    }
}
