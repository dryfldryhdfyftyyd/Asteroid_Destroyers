using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAsteroidField : MonoBehaviour
{
    public int numberOfAsteroids = 10;
    public float movementSpeed = 5f;
    public GameObject asteroidPrefab; // Reference to the asteroid prefab

    void Start()
    {
        GenerateAsteroidField();
    }

    void GenerateAsteroidField()
    {
        

        for (int i = 0; i < numberOfAsteroids; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-50f, 50f), Random.Range(0f, 100f), Random.Range(-50f, 50f));
            Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

            GameObject asteroid = Instantiate(asteroidPrefab, randomPosition, randomRotation);
            asteroid.transform.localScale = new Vector3(2f, 2f, 2f); 

            Rigidbody asteroidRigidbody = asteroid.GetComponent<Rigidbody>();

            if (asteroidRigidbody == null)
            {
                // Add Rigidbody if not already present
                asteroidRigidbody = asteroid.AddComponent<Rigidbody>();
            }

            asteroidRigidbody.velocity = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f) * movementSpeed;

            
        }
    }
}
