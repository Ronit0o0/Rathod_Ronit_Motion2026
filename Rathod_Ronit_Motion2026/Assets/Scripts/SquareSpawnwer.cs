using UnityEngine;
using UnityEngine.InputSystem;

public class SquareSpawnwer : MonoBehaviour
{
    public Vector2 point1;
    public Vector2 point2;
    public Vector2 point3;
    public Vector2 point4;
    public Camera gameCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentMousePosition = Mouse.current.position.ReadValue();

        Vector3 worldMousePosition = gameCamera.ScreenToWorldPoint(currentMousePosition);

        worldMousePosition.z = 0f;

        Vector2 point1plus2 = point1 - point2;

        Debug.DrawLine(worldMousePosition, point1plus2, Color.white);



    }
}
