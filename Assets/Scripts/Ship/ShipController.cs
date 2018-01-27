using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float Speed;
    public float SteeringSpeed;

    private Rigidbody rb;
    private bool rotate;

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
    }

    void FixedUpdate()
    {
        rb.velocity = transform.forward * Speed;
        if (target != null)
        {

            transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, Utils.GetPositionWithoutY(target.position) - Utils.GetPositionWithoutY(transform.position), SteeringSpeed * Time.fixedDeltaTime, 0.0f), Vector3.up);
            
        }
    }

    public void ChangeDestination(Transform target)
    {
        this.target = target;
    }
}
