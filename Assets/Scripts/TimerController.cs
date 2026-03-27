using UnityEngine;
using TMPro; // สำหรับจัดการ TextMeshPro

public class TimerController : MonoBehaviour
{
    public TextMeshProUGUI timerText; // ลาก Text ในหน้าจอมาใส่ช่องนี้
    private float startTime;
    private bool isFinished = false;

    void Start()
    {
        // เริ่มนับเวลาตั้งแต่เริ่มเกม
        startTime = Time.time;
    }

    void Update()
    {
        if (isFinished) return;

        // คำนวณเวลาที่ผ่านไป
        float t = Time.time - startTime;

        // แปลงเป็น นาที : วินาที : มิลลิวินาที
        string minutes = ((int)t / 60).ToString("00");
        string seconds = (t % 60).ToString("00");
        string milliseconds = ((t * 100) % 100).ToString("00");

        // แสดงผลบนหน้าจอ
        timerText.text = minutes + ":" + seconds + ":" + milliseconds;
    }

    // ฟังก์ชันสำหรับหยุดเวลาเมื่อเข้าเส้นชัย
    public void Finish()
    {
        isFinished = true;
        timerText.color = Color.yellow; // เปลี่ยนสีเมื่อจบเกม
    }
}