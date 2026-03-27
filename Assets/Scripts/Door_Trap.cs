using UnityEngine;

public class AutoDoor : MonoBehaviour
{
    public float moveDistance = 5f; // ระยะขึ้น-ลง
    public float speed = 2f;

    private Vector3 startPos;
    private Vector3 endPos;
    private bool goingUp = true;

    void Start()
    {
        startPos = transform.position;
        endPos = startPos + new Vector3(0, moveDistance, 0);
    }

    void Update()
    {
        if (goingUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.deltaTime);

            if (transform.position == endPos)
                goingUp = false;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime);

            if (transform.position == startPos)
                goingUp = true;
        }
    }
}