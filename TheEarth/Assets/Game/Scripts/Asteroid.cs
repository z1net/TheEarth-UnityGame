using System;
using UnityEngine;



[RequireComponent(typeof(Rotater))]
public class Asteroid : MonoBehaviour
{
    private PauseManager pauseManager;

    private Rotater rotater;

    private AsteroidClickHandler handler;



    public Rotater Rotater => rotater;

    public AsteroidClickHandler Handler => handler;



    public event Action OnDestroyed;



    private void OnEnable()
    {
        rotater = GetComponent<Rotater>();

        handler = GetComponent<AsteroidClickHandler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Earth earth) && !pauseManager.IsGamePaused())
        {
            Destroy(gameObject);
            OnDestroyed?.Invoke();

            earth.TakeDamage();
        }
    }



    public void Initialize(PauseManager pauseManager)
    {
        this.pauseManager = pauseManager;

        rotater.Initialize(pauseManager);

        handler.Initialize(pauseManager);
    }
}
