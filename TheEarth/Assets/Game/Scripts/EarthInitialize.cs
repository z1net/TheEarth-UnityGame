using UnityEngine;



[RequireComponent(typeof(Earth))]
public class EarthInitialize : MonoBehaviour
{
    [SerializeField] private PauseManager pauseManager;



    private void Start()
    {
        GetComponent<Earth>().GetComponent<Rotater>().Initialize(pauseManager);
    }
}
