using UnityEngine;

public class GetScreenSize : MonoBehaviour
{
    [SerializeField] private GameObject littleteennytinypleepleeboop;

    void Start()
    {
        // Screen position in pixels (top-right corner, with a 48px offset upward)
        Vector3 screenPos = new Vector3(Screen.width, Screen.height + 48f, 0f);

        // Convert pixel coordinates -> world coordinates
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);

        // Make sure z is correct (since ScreenToWorldPoint uses camera’s near clip plane by default)
        worldPos.z = 1000f;

        // Spawn your pet in the correct world position
        Instantiate(littleteennytinypleepleeboop, (Vector2)worldPos, Quaternion.identity);
    }
}