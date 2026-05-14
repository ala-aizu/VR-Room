using UnityEngine;


public class PhysicsTargetController : MonoBehaviour
{
    private Rigidbody rb;
    private int currentState = 0;
    public float spinTorque = 10f;
    public float floatForce = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void CycleState()
    {
        currentState = (currentState + 1) % 3; 

        ApplyStateSetup();
    }

    private void ApplyStateSetup()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        switch (currentState)
        {
            case 0:
                rb.useGravity = true;
                break;
            case 1:
                rb.useGravity = false; 
                break;
            case 2:
                rb.useGravity = false;
                break;
        }
    }

    void FixedUpdate()
    {
        switch (currentState)
        {
            case 0:
                break;
            case 1:
                Method1_Spin();
                break;
            case 2:
                Method2_Float();
                break;
        }
    }

    private void Method1_Spin()
    {
        rb.AddTorque(Vector3.up * spinTorque, ForceMode.Acceleration);
    }

    private void Method2_Float()
    {
        rb.AddForce(Vector3.up * floatForce, ForceMode.Acceleration);
    }
}