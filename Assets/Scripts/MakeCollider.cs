using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class MakeCollider : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    void Awake()
    {
        float width = this.transform.position.z * 1.026f;
        float height = this.transform.position.z * 0.576f;

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
