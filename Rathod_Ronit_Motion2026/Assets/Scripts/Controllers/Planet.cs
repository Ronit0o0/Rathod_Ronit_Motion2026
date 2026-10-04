using System.Collections.Generic;
using Unity.AppUI.UI;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public GameObject planet;
    private GameObject currentPlanet;
    public float timer = 0f;
    public float spawnRate = 5f;
    public Player playerScript;
    public List<float> circlePoints;
    public float radius = 0f;
    private Color circleColor = Color.white;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlanetMechanic();
    }

    public void PlanetMechanic()
    {
        timer += Time.deltaTime;

        Vector2 randomSpawn = new Vector2(Random.Range(-23.5f, 18f), Random.Range(-9.4f, 10.5f));

        if (timer >= spawnRate)
        {
            currentPlanet = Instantiate(planet, randomSpawn, Quaternion.identity);
            timer = 0f;
        }

        float distanceToRadius = Vector2.Distance(playerScript.transform.position, currentPlanet.transform.position);

        if (distanceToRadius <= radius)
        {
            circleColor = Color.red;
            playerScript.speed = 2f;
        }
        else
        {
            circleColor = Color.white;
        }

        for (int i = 0; i < circlePoints.Count; i++)
        {
            circlePoints[i] = i * (360 / circlePoints.Count);
        }

        for (int i = 0; i < circlePoints.Count; i++)
        {
            if (i < circlePoints.Count - 1)
            {
                Vector2 startPosition = new Vector2(Mathf.Cos(circlePoints[i] * Mathf.Deg2Rad), Mathf.Sin(circlePoints[i] * Mathf.Deg2Rad)) * radius;
                Vector2 endPosition = new Vector2(Mathf.Cos(circlePoints[i + 1] * Mathf.Deg2Rad), Mathf.Sin(circlePoints[i + 1] * Mathf.Deg2Rad)) * radius;
                Debug.DrawLine(startPosition + (Vector2)currentPlanet.transform.position, endPosition + (Vector2)currentPlanet.transform.position, circleColor);
            }

            else
            {
                Vector2 startPosition = new Vector2(Mathf.Cos(circlePoints[i] * Mathf.Deg2Rad), Mathf.Sin(circlePoints[i] * Mathf.Deg2Rad)) * radius;
                Vector2 endPosition = new Vector2(Mathf.Cos(circlePoints[0] * Mathf.Deg2Rad), Mathf.Sin(circlePoints[0] * Mathf.Deg2Rad)) * radius;
                Debug.DrawLine(startPosition + (Vector2)currentPlanet.transform.position, endPosition + (Vector2)currentPlanet.transform.position, circleColor);
            }
        }

    }
}
