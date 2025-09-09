using UnityEngine;

public class PetMovement : MonoBehaviour
{
    public float speed = 200f;

    private Vector3 targetPosition;
    private Rect taskbarRect;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
        taskbarRect = TaskbarInfo.GetTaskbarRect();
        SetRandomTarget();
    }

    void Update()
    {
        // Move towards target
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // If reached target, pick a new one
        if (Vector3.Distance(transform.position, targetPosition) < 1f)
        {
            SetRandomTarget();
        }
    }

    void SetRandomTarget()
    {
        // Random X along taskbar
        float x = Random.Range(taskbarRect.xMin, taskbarRect.xMax);
        // Y = top of taskbar
        float y = taskbarRect.yMin;

        // Convert screen position to world position
        Vector3 screenPos = new Vector3(x, y, cam.transform.position.z); // distance from camera
        targetPosition = cam.ScreenToWorldPoint(screenPos);

        // Force pet to stay at Z = 0
        targetPosition.z = 0;
    }

}