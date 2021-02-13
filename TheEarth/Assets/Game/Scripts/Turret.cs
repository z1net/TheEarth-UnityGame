using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private float delayBeetwenFire;

    public static float FireDelayMultiplier { get; set; } = 1;

    public static float ShootMaxDistance { get; set; } = 15f;

    private float lastShoot;



    private void Update()
    {
        foreach (GameObject asteroid in GameObject.FindGameObjectsWithTag("Asteroid"))
        {
            if (Vector2.Distance(asteroid.transform.position, gameObject.transform.position) < ShootMaxDistance)
            {
                if ((Time.time - lastShoot) >= delayBeetwenFire / FireDelayMultiplier)
                {
                    Destroy(asteroid);
                    OnTurretDestroyedAsteroid?.Invoke();
                    lastShoot = Time.time;
                }
            }
        }
    }



    public delegate void TurretDestoryHandler();



    public static event TurretDestoryHandler OnTurretDestroyedAsteroid;
}
