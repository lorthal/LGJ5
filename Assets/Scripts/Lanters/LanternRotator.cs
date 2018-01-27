using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternRotator : MonoBehaviour
{

    public float rotationSpeed;
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + Time.unscaledDeltaTime * rotationSpeed, 0);
    }
}
