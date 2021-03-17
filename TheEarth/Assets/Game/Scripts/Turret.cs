using System;
using UnityEngine;



public class Turret : MonoBehaviour
{
    [SerializeField] private float intervalBetweenShoot;



    private float lastShoot;



    public float FireDelayMultiplier { get; set; } = 1;

    public float ShootMaxDistance { get; set; } = 15f;



    public event Action OnAsteroidDestroyed;

    public event Action OnBeforeAsteroidDestroyed;



    private void Update()
    {
        foreach (Asteroid asteroid in FindObjectsOfType(typeof(Asteroid)))
        {
            if (Vector2.Distance(asteroid.transform.position, gameObject.transform.position) < ShootMaxDistance)
            {
                if ((Time.time - lastShoot) >= intervalBetweenShoot / FireDelayMultiplier)
                {
                    OnBeforeAsteroidDestroyed?.Invoke();

                    Destroy(asteroid.gameObject);

                    OnAsteroidDestroyed?.Invoke();

                    lastShoot = Time.time;
                }
            }
        }
    }
}
