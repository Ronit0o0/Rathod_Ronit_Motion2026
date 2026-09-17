using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.VisualScripting;


public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    void Update()
    {
        if (Keyboard.current.bKey.wasPressedThisFrame)
        {
            //SpawnBombAtOffset(new Vector2(0, 1));
            //SpawnBombOnRandomCorner(1f);
            SpawnBombTrail(transform.position,1f, 3);
        }

        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            WarpDrive();
        }

        DetectAsteroids(2f, asteroidTransforms);
    }

    void SpawnBombAtOffset(Vector2 inOffset)
    //Other Approaches to this method:
    //SpawnBombAtOffset(Vector2.up)
    //SpawnBombAtOffset(new Vector2 (0,1))
    {
        Vector2 spawnBomb = (Vector2)transform.position + inOffset;
        Instantiate(bombPrefab, spawnBomb, Quaternion.identity, bombsTransform);
    }

    public void SpawnBombTrail(Vector2 inPosition, float inBombSpacing, int inNumber)
    {
        for (int i = 0; i < inNumber; i++)
        {
            Vector2 spawnBomb = inPosition - new Vector2(0, 1 + (inBombSpacing * i));
            Instantiate(bombPrefab, spawnBomb, Quaternion.identity, bombsTransform);
        }
        
    }

    void WarpDrive()
    {

        Vector2 warpDirection = (Vector2)(enemyTransform.position - transform.position);

        warpDirection.Normalize();

         transform.position = warpDirection;
    }

    public void SpawnBombOnRandomCorner(float inDistance)
    {
        Vector2 spawn = (Vector2)transform.position + new Vector2 (Random.Range(-1, 2), Random.Range(-1, 2)) * inDistance;
    }

    public static float GetMagnitude(Vector2 vector)
    {
        return Mathf.Sqrt(vector.x * vector.x + vector.y * vector.y);
    }
    public void DetectAsteroids(float inMaxRange, List<Transform> inAsteroids)
    {
        for (int i = 0; i < inAsteroids.Count; i++)
        {
            Transform asteroid = inAsteroids[i];

            Vector2 directionToAsteroid = (Vector2)asteroid.position - (Vector2)transform.position;

            float magtoAsteroid = GetMagnitude(directionToAsteroid);

            Vector2 normalizeAsteroidDistance = directionToAsteroid.normalized * 2.5f;

            if (magtoAsteroid <= inMaxRange)
            {
                Debug.DrawLine(transform.position, (Vector2)asteroid.position, Color.white);
                //asteroids are within the max range then draw a line from the player to the asteroid
            }
        }
    }
}