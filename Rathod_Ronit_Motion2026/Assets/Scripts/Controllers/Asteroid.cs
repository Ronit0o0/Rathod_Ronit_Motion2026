using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;
    Vector3 randomPoint;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);

        Vector3 randomDirectionNorm = randomDirection.normalized * maxFloatDistance;

        randomPoint = transform.position + randomDirectionNorm;
    }

    // Update is called once per frame
    void Update()
    {
        AsteroidMovement();
    }

    void AsteroidMovement()
    {
       

        Vector3 directonToTarget = randomPoint - transform.position;

        float directionToTargetMag = directonToTarget.magnitude;

        if (directionToTargetMag > arrivalDistance)
        {
            transform.position += directonToTarget.normalized * moveSpeed * Time.deltaTime;
        }
        else
        {
            Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);

            Vector3 randomDirectionNorm = randomDirection.normalized * maxFloatDistance;

            randomPoint = transform.position + randomDirectionNorm;
        }
    }
}
