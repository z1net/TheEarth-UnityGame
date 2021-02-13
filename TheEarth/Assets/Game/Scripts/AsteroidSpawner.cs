using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private float spawnDelay;

    [SerializeField] private GameObject asteroid;

    [SerializeField] private Sprite[] asteroidSprites = new Sprite[5];

    [SerializeField] private GameObject earth;

    private float lastSpawn;

    public static float SpawnerMultiplier { get; set; } = 1;


    private void Update()
    {
        foreach (GameObject asteroid in GameObject.FindGameObjectsWithTag("Asteroid"))
        {
            asteroid?.transform.Translate(earth.transform.position * Time.deltaTime / 5, Space.World);
        }

        if ((Time.time - lastSpawn) >= spawnDelay / SpawnerMultiplier)
        {
            spawnAsteroid();
        }
    }

    private void spawnAsteroid()
    {
        int asteroidIndex = Random.Range(0, 4);

        float y = Random.Range(-5, 5);

        Vector2 position = new Vector2(-20, y);

        Sprite randomAsteroidSprite = asteroidSprites[asteroidIndex];

        asteroid.GetComponent<Image>().sprite = randomAsteroidSprite;

        Instantiate(asteroid, position, Quaternion.identity, transform);
        lastSpawn = Time.time;
    }
}
