using UnityEngine;
using UnityEngine.EventSystems;



public class AsteroidClickHandler : MonoBehaviour, IPointerClickHandler
{
    private PauseManager pauseManager;



    public delegate void AsteroidClickedHandler(Asteroid asteroid, PointerEventData data, ref bool allow);

    public event AsteroidClickedHandler OnClickRequested;



    public void OnPointerClick(PointerEventData data)
    {
        if (!pauseManager.IsGamePaused() && data.pointerClick.TryGetComponent(out Asteroid asteroid))
        {
            bool allow = true;

            OnClickRequested?.Invoke(asteroid, data, ref allow);

            if (!allow) { return; }

            Destroy(asteroid.gameObject);
        }
    }



    public void Initialize(PauseManager pauseManager)
    {
        this.pauseManager = pauseManager;
    }
}