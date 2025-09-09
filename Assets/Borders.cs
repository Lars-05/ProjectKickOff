using UnityEngine;

public class Borders : MonoBehaviour
{
    public Camera cam;

    void Start()
    {
        // 50,50 pixels from bottom-left
        Vector3 pixelPos = new Vector3(50, 50, 1f); // z=1 in front of camera
        Vector3 worldPos = cam.ScreenToWorldPoint(pixelPos);

        transform.position = worldPos;
    }
}
