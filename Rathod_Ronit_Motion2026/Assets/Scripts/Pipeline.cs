using UnityEngine;
using UnityEngine.InputSystem;

public class Pipeline : MonoBehaviour
{
    public Camera gameCamera;
    public float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        // Vector3 currentMousePosition = Mouse.current.position.ReadValue();

        // Vector3 worldMousePosition = gameCamera.ScreenToWorldPoint(currentMousePosition);

        // worldMousePosition.z = 0f;

        // timer += Time.deltaTime;

        // if(Mouse.current.leftButton.isPressed)
        // {
        //     timer += Time.deltaTime;
        //     Debug.DrawLine( , worldMousePosition, Color.white); 
        // } else
        // {
        //     timer = 0f;
        //     float result = Mathf.Sqrt(mouseClickPOS.x * worldMousePosition.x + mouseClickPOS.y * worldMousePosition.y);
        //     Debug.Log(result);
        // }
    }
    public void drawPipeline(InputAction.CallbackContext context)
    {
        Vector3 currentMousePosition = Mouse.current.position.ReadValue();

        Vector3 worldMousePosition = gameCamera.ScreenToWorldPoint(currentMousePosition);

        worldMousePosition.z = 0f;

        Vector2 mouseClickPOS = context.ReadValue<Vector2>();

        timer += Time.deltaTime;

        if (context.performed && timer > 0.1f)
        {
            Debug.DrawLine(mouseClickPOS, worldMousePosition, Color.white);
        }

        if (context.canceled)
        {
            timer = 0f;
            float result = Mathf.Sqrt(mouseClickPOS.x * worldMousePosition.x + mouseClickPOS.y * worldMousePosition.y);
            Debug.Log(result);
        }
    }
}
