using UnityEngine;
using UnityEngine.UI;



public class Rotater : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;



    private Image currentTarget;

    private float currentSpeed;

    private PauseManager pauseManager;



    public float SpeedMultiplier { get; private set; } = 1;

    

    private void Start()
    {
        currentTarget = GetComponent<Image>();
    }

    private void Update()
    {
        if (pauseManager != null && !pauseManager.IsGamePaused())
        {
            currentSpeed += rotationSpeed + Time.deltaTime;

            currentTarget.transform.rotation = Quaternion.Euler(0, 0, currentSpeed * SpeedMultiplier);
        }
    }



    public void Initialize(PauseManager pauseManager)
    {
        this.pauseManager = pauseManager;
    }
}
