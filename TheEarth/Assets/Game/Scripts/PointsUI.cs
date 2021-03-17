using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



[RequireComponent(typeof(PointsStorage))]
public class PointsUI : MonoBehaviour
{
    [SerializeField] private AsteroidSpawner spawner;

    [SerializeField] private Text pointsText;

    [SerializeField] private Turret turret;



    private PointsStorage storage;



    private void Start()
    {
        storage = GetComponent<PointsStorage>();
    }



    #region * Events (Sub/Unsub) *
    private void OnEnable()
    {
        spawner.OnSpawned += onAsteroidSpawned;

        turret.OnAsteroidDestroyed += onAsteroidDestroyed;
    }

    

    private void OnDisable()
    {
        spawner.OnSpawned -= onAsteroidSpawned;

        turret.OnAsteroidDestroyed -= onAsteroidDestroyed;
    }
    #endregion



    #region --- Events ---
    private void onAsteroidSpawned(Asteroid asteroid)
    {
        asteroid.Handler.OnClickRequested += onAsteroidClicked;

        asteroid.OnDestroyed += () =>
        {
            UpdatePoints();
            asteroid.OnDestroyed -= () => { };
        };
    }

    private void onAsteroidClicked(Asteroid asteroid, PointerEventData data, ref bool allow)
    {
        UpdatePoints();
        asteroid.Handler.OnClickRequested -= onAsteroidClicked;
    }

    private void onAsteroidDestroyed()
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
