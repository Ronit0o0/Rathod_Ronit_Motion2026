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
            SpawnBombAtOffset(new Vector2(0, 1));
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

    void WarpDrive()
    {
        Vector2 warpDirection = (Vector2)(enemyTransform.position - transform.position);

        warpDirection.Normalize();

        transform.position = warpDirection;


    }
}
