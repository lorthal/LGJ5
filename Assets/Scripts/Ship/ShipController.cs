using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float Speed;
    public float SteeringSpeed;

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
        rb.velocity = transform.forward * Speed;
        Debug.DrawRay(transform.position, transform.forward);
        if (target != null)
        {

            transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, Utils.GetPositionWithoutY(target.position) - Utils.GetPositionWithoutY(transform.position), SteeringSpeed * Time.deltaTime, 0.0f), Vector3.up);
            
        }
    }

    public void ChangeDestination(Transform target)
    {
        this.target = target;
    }
}
