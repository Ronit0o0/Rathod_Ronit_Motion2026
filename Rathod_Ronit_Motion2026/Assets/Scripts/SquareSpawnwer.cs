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

        Vector2 point11 = (Vector2)worldMousePosition + new Vector2 (point1.x, point1.y);
        Vector2 point22 = (Vector2)worldMousePosition + new Vector2(point2.x, point2.y);
        Vector2 point33 = (Vector2)worldMousePosition + new Vector2(point3.x, point3.y);
        Vector2 point44 = (Vector2)worldMousePosition + new Vector2(point4.x, point4.y);

        Debug.DrawLine(point11, point22, Color.white);
        Debug.DrawLine(point22, point33, Color.white);
        Debug.DrawLine(point33, point44, Color.white);
        Debug.DrawLine(point44, point11, Color.white);




    }
}
