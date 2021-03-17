using System;
using UnityEngine;
using UnityEngine.UI;



public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private float spawnDelay;

    [SerializeField] private Asteroid asteroid;

    [SerializeField] private Sprite[] asteroidSprites = new Sprite[5];

    [SerializeField] private GameObject earth;

    [SerializeField] private PauseManager pauseManager;



    private float lastSpawn;



    public float SpawnerMultiplier { get; set; } = 1;



    public event Action<Asteroid> OnSpawned;



    private void Update()
    {
        foreach (Asteroid asteroid in FindObjectsOfType(typeof(Asteroid)))
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
        int asteroidIndex = UnityEngine.Random.Range(0, 4);

        Vector2 position = new Vector2(-20, UnityEngine.Random.Range(-5, 5));

        Sprite randomAsteroidSprite = asteroidSprites[asteroidIndex];

        asteroid.GetComponent<Image>().sprite = randomAsteroidSprite;

        Asteroid spawned = Instantiate(asteroid, position, Quaternion.identity, transform);

        spawned.Initialize(pauseManager);

        OnSpawned?.Invoke(spawned);

        lastSpawn = Time.time;
    }
}
