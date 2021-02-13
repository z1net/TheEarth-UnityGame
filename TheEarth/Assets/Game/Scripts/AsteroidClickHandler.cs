using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AsteroidClickHandler : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!PauseManager.IsGamePaused())
        {
            bool allow = true;

            OnAsteroidClickRequested?.Invoke(gameObject, eventData, ref allow);

            if (!allow) { return; }

            Destroy(gameObject);
        }
    }



    public delegate void AsteroidClickedHandler(GameObject clickedObject, PointerEventData data, ref bool allow);



    public static event AsteroidClickedHandler OnAsteroidClickRequested;
}
