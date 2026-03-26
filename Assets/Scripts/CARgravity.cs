using UnityEngine;

public class CenterOfMass : MonoBehaviour
{
    public Vector3 centerOfMassOffset;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // ย้ายจุด CoM ลงไปที่ตำแหน่งที่เราตั้งไว้
        rb.centerOfMass = centerOfMassOffset;
    }
}