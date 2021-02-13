using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotater : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;

    [HideInInspector] public float SpeedMultiplier { get; set; } = 1;

    private Image currentTarget;

    private float currentSpeed;



    private void Start()
    {
        currentTarget = GetComponent<Image>();
    }

    private void Update()
    {
        if (!PauseManager.IsGamePaused())
        {
            currentSpeed += rotationSpeed + Time.deltaTime;

            currentTarget.transform.rotation = Quaternion.Euler(0, 0, currentSpeed * SpeedMultiplier);
        }
    }
}
