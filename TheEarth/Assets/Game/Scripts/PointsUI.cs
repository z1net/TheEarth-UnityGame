using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(PointsStorage))]
public class PointsUI : MonoBehaviour
{
    [SerializeField] private Text pointsText;

    private PointsStorage storage;



    private void Start()
    {
        storage = GetComponent<PointsStorage>();
    }



    #region * Events (Sub/Unsub) *
    private void OnEnable()
    {
        Asteroid.OnAsteroidDestroyed += onAsteroidDestroyed;



        AsteroidClickHandler.OnAsteroidClickRequested += onAsteroidClickedHandler;



        Turret.OnTurretDestroyedAsteroid += onTurretDestroyedAsteroid;
    }



    private void OnDisable()
    {
        Asteroid.OnAsteroidDestroyed -= onAsteroidDestroyed;



        AsteroidClickHandler.OnAsteroidClickRequested -= onAsteroidClickedHandler;



        Turret.OnTurretDestroyedAsteroid -= onTurretDestroyedAsteroid;
    }
    #endregion



    #region --- Events ---
    private void onAsteroidDestroyed()
    {
        UpdatePoints();
    }

    private void onAsteroidClickedHandler(GameObject clickedObject, PointerEventData data, ref bool allow)
    {
        UpdatePoints();
    }

    private void onTurretDestroyedAsteroid()
    {
        UpdatePoints();
    }
    #endregion



    public void UpdatePoints(bool incerasePoints = true)
    {
        if (incerasePoints) { storage.IncreasePoints(); }

        pointsText.text = storage.Points.ToString();
    }
}
