using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransmitterController : MonoBehaviour
{
    public float StartPackages;
    private float packages;
    public float packegesSendPerSecond;

    public ParticleSystem RangeParticleSystem;
    public ParticleSystem TransmissionParticleSystem;

    public Vector2 DistanceMultiplierRange;

    private SphereCollider sphere;

    private ParticleSystem.Particle[] particles;

    private Color rangeParticleStartColor;
    private void Start()
    {
        sphere = GetComponent<SphereCollider>();
        rangeParticleStartColor = RangeParticleSystem.main.startColor.color;
        packages = StartPackages;
    }

    private void Update()
    {
        if (ReciverManager.Instance.GameState != ReciverManager.LevelState.Running && TransmissionParticleSystem.isPlaying)
        {
            TransmissionParticleSystem.Stop();
        }
        rangeParticleStartColor.a = packages / StartPackages;
        var mainModule = RangeParticleSystem.main;
        mainModule.startColor = rangeParticleStartColor;
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
            if (packages > 0 && !TransmissionParticleSystem.isPlaying)
            {
                TransmissionParticleSystem.Play();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && ReciverManager.Instance.GameState ==
            ReciverManager.LevelState.Running)
        {
            if (TransmissionParticleSystem.isPlaying)
            {
                TransmissionParticleSystem.Stop();
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
                    new ParticleSystem.Particle[TransmissionParticleSystem.particleCount];

                TransmissionParticleSystem.GetParticles(particles);

                for (int i = 0; i < particles.Length; i++)
                {
                    ParticleSystem.Particle p = particles[i];
                    p.rotation = Vector3.Angle(TransmissionParticleSystem.transform.forward,
                        targetPosition - TransmissionParticleSystem.transform.position);
                    p.position = Vector3.Lerp(TransmissionParticleSystem.transform.position, targetPosition, 1 - (p.remainingLifetime/p.startLifetime));

                    particles[i] = p;
                }

                TransmissionParticleSystem.SetParticles(particles, particles.Length);

                ReciverManager.Instance.SendPackage(sendedPackages);
                packages -= sendedPackages;
            }
            else
            {
                if (TransmissionParticleSystem.isPlaying)
                {
                    TransmissionParticleSystem.Stop();
                }
            }
        }

        if (ReciverManager.Instance.GameState == ReciverManager.LevelState.Won ||
            ReciverManager.Instance.GameState == ReciverManager.LevelState.Lost)
        {
            if (TransmissionParticleSystem.isPlaying)
            {
                TransmissionParticleSystem.Stop();
            }
        }
    }
}
