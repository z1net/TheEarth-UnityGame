using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static PauseManager;

public class Asteroid : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Earth>(out Earth earth) && !PauseManager.IsGamePaused())
        {
            Destroy(gameObject);
            OnAsteroidDestroyed?.Invoke();

            earth.TakeDamage();
        }
    }



    public delegate void AsteroidDestroyHandler();


    public static event AsteroidDestroyHandler OnAsteroidDestroyed;
}
