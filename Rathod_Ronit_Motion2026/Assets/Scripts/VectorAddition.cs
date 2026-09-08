using UnityEngine;
using UnityEngine.InputSystem;

public class VectorAddition : MonoBehaviour
{
    public Transform rtransform;
    public Transform btransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool isRPressed = Keyboard.current.rKey.isPressed;
        bool isBPressed = Keyboard.current.bKey.isPressed;

        Vector2 origin = new Vector2(0,0);

        Vector2 rPos = new Vector2(rtransform.position.x, rtransform.position.y);
        Vector2 bPos = new Vector2(btransform.position.x, btransform.position.y);;

        Vector2 rplusb = rPos + bPos;

        if(isRPressed)
        {
            Debug.DrawLine(origin, rPos, Color.red);
        }

        if(isBPressed)
        {
            Debug.DrawLine(origin, bPos, Color.blue);
        }

        if(isRPressed && isBPressed)
        {
            Debug.DrawLine(origin, rplusb, Color.purple);
        }
    }
}
