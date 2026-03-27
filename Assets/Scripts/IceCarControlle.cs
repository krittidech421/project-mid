using UnityEngine;

public class IceCarController : MonoBehaviour
{
    public WheelCollider[] wheels; // ลากล้อรถทั้งหมดมาใส่ที่นี่
    public float iceStiffness = 0.5f; // ค่าความหนึบตอนอยู่บนน้ำแข็ง (ยิ่งน้อยยิ่งลื่น)
    public float normalStiffness = 1.0f; // ค่าความหนึบปกติ

    void Update()
    {
        // เช็คว่ารถเหยียบพื้นที่มี Tag ว่า "Ice" หรือเปล่า
        if (IsOnIce())
        {
            SetFriction(iceStiffness);
        }
        else
        {
            SetFriction(normalStiffness);
        }
    }

    void SetFriction(float stiffness)
    {
        foreach (WheelCollider wheel in wheels)
        {
            WheelFrictionCurve sideFriction = wheel.sidewaysFriction;
            sideFriction.stiffness = stiffness;
            wheel.sidewaysFriction = sideFriction;

            // ปรับ Forward Friction ด้วยถ้าอยากให้ล้อฟรีตอนออกตัว
            WheelFrictionCurve forwardFriction = wheel.forwardFriction;
            forwardFriction.stiffness = stiffness;
            wheel.forwardFriction = forwardFriction;
        }
    }

    bool IsOnIce()
    {
        RaycastHit hit;
        // ยิง Ray ลงไปที่พื้นเพื่อเช็ค Tag
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 2f))
        {
            return hit.collider.CompareTag("Ice");
        }
        return false;
    }
}