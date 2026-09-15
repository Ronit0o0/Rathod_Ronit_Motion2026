using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
        //Vector2 spawnBomb = transform.position + 
        //Instantiate(bombPrefab, spawnBomb, Quaternion.identity, bombsTransform);
    }
}
