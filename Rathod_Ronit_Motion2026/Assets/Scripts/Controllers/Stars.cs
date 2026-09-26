using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;
    public float timer = 0f;
    int currentStar;
    // Update is called once per frame
    void Update()
    {
        DrawConstellation();
    }

    public void DrawConstellation()
    {
        timer += Time.deltaTime;

        Vector3 startPoint = starTransforms[currentStar].position;
        Vector3 endPoint = starTransforms[currentStar + 1].position;
        
        // Vector3 directionToTarget = endPoint - endPoint;
        

        for(int i = 0; i < starTransforms.Count; i++)
        {
            

            Debug.DrawLine(startPoint, endPoint, Color.white, drawingTime * Time.deltaTime);

            if(timer >= drawingTime)
            {
                if(currentStar == starTransforms.Count)
                {
                    currentStar = 0;
                    timer = 0f; 
                }
                else
                {
                    currentStar = currentStar + 1;
                    startPoint = starTransforms[currentStar].position;
                    endPoint = starTransforms[currentStar + 1].position;
                    timer = 0f; 
                }
                
            }
             
        }
    }
}

