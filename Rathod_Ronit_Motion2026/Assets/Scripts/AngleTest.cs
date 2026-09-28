using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class AngleTest : MonoBehaviour
{
    public List<float> angles;
    private Vector2 origin = Vector2.zero;
    private int currentIndex = 0;
    public float circleRadius;

    public Vector3 circleOffset;

    public float shiftProgress;
    public float shiftDuration;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float fortyFiveAngle = 45f;

        float ffdInRadians = fortyFiveAngle * Mathf.Deg2Rad;

        float twoPieRadians = 2f * Mathf.PI;
        float tprInDegrees = twoPieRadians * Mathf.Rad2Deg;

        float currentAngle = 90f;
        float cosValue = Mathf.Cos(currentAngle * Mathf.Deg2Rad);
        float sinValue = Mathf.Sin(currentAngle * Mathf.Deg2Rad);


    }

    // Update is called once per frame
    void Update()
    {    
        shiftProgress += Time.deltaTime;

        if(shiftProgress > shiftDuration )
        {
            currentIndex++;
            shiftProgress = 0f;

            if (currentIndex >= angles.Count)
            {
                currentIndex = 0;
            }
        }

        //if (Keyboard.current.spaceKey.wasPressedThisFrame)
        //    {
        //        currentIndex = currentIndex + 1;

        //        if (currentIndex >= angles.Count)
        //        {
        //            currentIndex = 0;
        //        }

                float angleInRadians = angles[currentIndex] * Mathf.Deg2Rad;

                float cosValue = Mathf.Cos(angleInRadians);
                float sinValue = Mathf.Sin(angleInRadians);

                Vector2 anglesPosition = new Vector2(cosValue, sinValue) * circleRadius;

                Debug.DrawLine(origin, anglesPosition, Color.white);

            
        
    }
}
