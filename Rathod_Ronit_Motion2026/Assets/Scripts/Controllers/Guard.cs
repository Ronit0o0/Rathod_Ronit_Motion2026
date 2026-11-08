using UnityEngine;

public class Guard : MonoBehaviour
{
    public Transform target;
    public float detectionDistance;
    public float detectionFOV;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Color firstConditionColour = Color.red;
        if (Vector3.Distance(transform.position, target.position) < detectionDistance)
        {
            firstConditionColour = Color.green;
        }
        Color secondConditionColour = Color.red;

        

        // Convert this into angle
        Vector3 guardToTarget = target.position - transform.position;

        //This will give us an angle the difference between the target and guard
        float guardToTargetAngle = Mathf.Atan2(guardToTarget.y, guardToTarget.x) * Mathf.Rad2Deg;

        //convert to angle using angle logic and then shift angle to left and right and then convert back into vector then draw the lines
        float facingAngle = Mathf.Atan2(transform.up.y, transform.up.x) * Mathf.Rad2Deg;

        //This tell us how much of a difference there is between the two angles, this can be used to determine how far they are from eachother in degrees
        float deltaofAngles = Mathf.DeltaAngle(guardToTargetAngle, facingAngle);
        Debug.Log(deltaofAngles);

        if(detectionFOV /2 > Mathf.Abs(deltaofAngles))
        {
            secondConditionColour = Color.green;
        }

        //Check the math of the differnce in angle
        //Debug.Log("guardToTarget[" + guardToTargetAngle.ToString()+"] facingAngle[" + facingAngle.ToString()+"]");

        
        //This logic is to get the line going to the left and similar for the right line but instead subtracting from the detectionFOV 
        float leftAngle = facingAngle + detectionFOV / 2f;
        float rightAngle = facingAngle - detectionFOV / 2f;

        //This is to convert the angles to vector cords (x,y) and then center them on the player with transform.position and by multiplying by detectionDistance makes the lines reach the the circle around the Guard
        Vector3 leftVector = new Vector3(Mathf.Cos(leftAngle * Mathf.Deg2Rad), Mathf.Sin(leftAngle * Mathf.Deg2Rad)) * detectionDistance + transform.position;
        Vector3 rightVector = new Vector3(Mathf.Cos(rightAngle * Mathf.Deg2Rad), Mathf.Sin(rightAngle * Mathf.Deg2Rad)) * detectionDistance + transform.position;

        Debug.DrawLine(transform.position, leftVector, secondConditionColour);
        Debug.DrawLine(transform.position, rightVector, secondConditionColour);

        float circleAngleIncrement = 360f/12f;
        for (int i = 0; i < 12; i++)
        {
            float point1Angle = i * circleAngleIncrement * Mathf.Deg2Rad;
            Vector3 point1 = new Vector3(Mathf.Cos(point1Angle), Mathf.Sin(point1Angle)) * detectionDistance + transform.position; 
            float point2Angle = (i+1) *circleAngleIncrement * Mathf.Deg2Rad;
            Vector3 point2 = new Vector3(Mathf.Cos(point2Angle), Mathf.Sin(point2Angle)) * detectionDistance + transform.position;

            Debug.DrawLine(point1, point2, firstConditionColour);
        }


    }
}
