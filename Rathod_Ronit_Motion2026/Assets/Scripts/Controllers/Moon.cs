using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;
    public float radiusPub = 0f;
    public List<float> moonPoints;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OrbitalMotion(radiusPub, 2f, planetTransform);
    }

    public void OrbitalMotion(float radius, float speed, Transform target)
    {
        for (int i = 0; i < moonPoints.Count; i++)
        {
            moonPoints[i] = i * (360 / moonPoints.Count);
        }

        //float currentAngle = 0f;
        //float currentAgnle2 = 180f;

        //float MoonPosx = Mathf.Cos(currentAngle * Mathf.Deg2Rad) * radius;
        //float MoonPosy = Mathf.Sin(currentAngle * Mathf.Deg2Rad) * radius;

        //Vector2 MoonPos = new Vector2(MoonPosx, MoonPosy);

        //float MoonPosx2 = Mathf.Cos(currentAgnle2 * Mathf.Deg2Rad) * radius;
        //float MoonPosy2 = Mathf.Sin(currentAgnle2 * Mathf.Deg2Rad) * radius;

        //Vector2 MoonPos2 = new Vector2(MoonPosx2, MoonPosy2);

        for (int i = 0; i < moonPoints.Count; i++)
        {
            if (i < moonPoints.Count - 1)
            {
                Vector2 startPosition = new Vector2(Mathf.Cos(moonPoints[i] * Mathf.Deg2Rad), Mathf.Sin(moonPoints[i] * Mathf.Deg2Rad)) * radius;
                Vector2 endPosition = new Vector2(Mathf.Cos(moonPoints[i + 1] * Mathf.Deg2Rad), Mathf.Sin(moonPoints[i + 1] * Mathf.Deg2Rad)) * radius;
                //Debug.DrawLine(startPosition + (Vector2)transform.position, endPosition + (Vector2)transform.position, circleColor);
                Vector3.Lerp(startPosition + (Vector2)transform.position, endPosition + (Vector2)transform.position, speed * Time.deltaTime);
            }

            else
            {
                Vector2 startPosition = new Vector2(Mathf.Cos(moonPoints[i] * Mathf.Deg2Rad), Mathf.Sin(moonPoints[i] * Mathf.Deg2Rad)) * radius;
                Vector2 endPosition = new Vector2(Mathf.Cos(moonPoints[0] * Mathf.Deg2Rad), Mathf.Sin(moonPoints[0] * Mathf.Deg2Rad)) * radius;
                //Debug.DrawLine(startPosition + (Vector2)transform.position, endPosition + (Vector2)transform.position, circleColor);
                Vector3.Lerp(startPosition + (Vector2)transform.position, endPosition + (Vector2)transform.position, speed * Time.deltaTime);
            }
        }

        
    }
}
    