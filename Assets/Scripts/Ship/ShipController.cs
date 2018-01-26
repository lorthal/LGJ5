using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float Speed;

    private Rigidbody rb;
    private bool rotate;
    private Quaternion startRotation;

    private Transform target;

    public static ShipController Instance { get; private set; }


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startRotation = transform.rotation;
    }

    void Update()
    {
        rb.velocity = transform.rotation * -transform.forward * Speed;

        if (target != null)
        {
            transform.rotation = Quaternion.LookRotation(transform.position - new Vector3(target.position.x, transform.position.y, target.position.z)) * startRotation;
        }
    }

    public void ChangeDestination(Transform target)
    {
        this.target = target;
    }
}
