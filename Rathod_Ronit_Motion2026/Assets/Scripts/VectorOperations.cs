using UnityEngine;


public class VectorOperations : MonoBehaviour
{
    public Vector2 redVector; 
    public Vector2 blueVector;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 redPlusblue = redVector + blueVector;

        Vector2 origin = new Vector2(0,0);

        Vector2 redMinusBlue = redVector - blueVector;

        Debug.DrawLine(origin, redVector, Color.red);
        Debug.DrawLine(origin, blueVector, Color.blue);

        Debug.DrawLine(origin, redPlusblue, Color.purple);
        Debug.DrawLine(origin, redMinusBlue, Color.orange);
    }
}
