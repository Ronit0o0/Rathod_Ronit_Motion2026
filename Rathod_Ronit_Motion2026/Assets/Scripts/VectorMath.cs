using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class VectorMath : MonoBehaviour
{
    public Camera gameCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentMousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        DrawSquare(currentMousePos, 5f, Color.red, 0.5f);
    }

    public static float GetMagnitude(Vector2 vector)
    {
        return Mathf.Sqrt(vector.x * vector.x + vector.y * vector.y);
    }

    public static void DrawSquare(Vector2 centerPoint, float size, Color colour, float duration)
    {

        //VectorMath.DrawSquare();

        //EXAMPLES OF STATIC METHODS THAT WE CAN CALL ANYWHERE:
        //Vector2.Distance();
        //Debug.Log();
        //Mathf.Sqrt()

        //Center point & the size

        //Color

        //Duration how long to show

        //TOP LINE
        //Center point & the size
        Vector2 startPoint = centerPoint + new Vector2(-size, size);
        Vector2 endPoint = centerPoint + new Vector2(size, size);

        //Color
        Debug.DrawLine(startPoint, endPoint, colour, duration);

        //LEFT LINE
        //Center point & the size
        startPoint = centerPoint + new Vector2(-size, size);
        endPoint = centerPoint + new Vector2(-size, -size);

        //Color
        Debug.DrawLine(startPoint, endPoint, colour, duration);

        //BOTTOM LINE
        //Center point & the size
        startPoint = centerPoint + new Vector2(-size, -size);
        endPoint = centerPoint + new Vector2(size, -size);

        //Color
        Debug.DrawLine(startPoint, endPoint, colour, duration);

        //RIGHT LINE
        //Center point & the size
        startPoint = centerPoint + new Vector2(size, size);
        endPoint = centerPoint + new Vector2(size, -size);

        //Color
        Debug.DrawLine(startPoint, endPoint, colour, duration);

        //Duration how long to show

    }

    public static Vector2 GetNormalizedVector(Vector2 vector)
    {
        float sizeofVector = GetMagnitude(vector);

        //Gives us a vector that has a size of 1 that has the same direction as before
        Vector2 normalizeVector = new Vector2(vector.x, vector.y) / sizeofVector;

        return normalizeVector;
    }
}

   
