using Unity.VisualScripting;
using UnityEngine;

public class MakeCollider : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    void Awake()
    {
        float width = mainCamera.pixelWidth;
        float height = mainCamera.pixelHeight;

        var edgeCollider = this.AddComponent<EdgeCollider2D>();

        edgeCollider.points = new Vector2[]
        {
            new Vector2(width, -height),
            new Vector2(width, height),
            new Vector2(-width, height),
            new Vector2(-width, -height),
            new Vector2(width, -height)
        };

    }
}
