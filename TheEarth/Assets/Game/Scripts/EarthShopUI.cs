using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static EarthShop;

[RequireComponent(typeof(PointsUI))]
[RequireComponent(typeof(PointsStorage))]
public class EarthShopUI : MonoBehaviour
{
    [SerializeField] private Text turretSpeedMultiplierText;

    [SerializeField] private Text turretDistanceMultipliertText;

    [SerializeField] private GameObject shopPanel;

    private PointsStorage storage;

    private PointsUI pointsUI;



    private void Start()
    {
        storage = GetComponent<PointsStorage>();

        pointsUI = GetComponent<PointsUI>();
    }



    private void OnEnable()
    {
        OnPurchaseCompleted += onPurchaseCompleted;



        PauseManager.OnPauseSetted += onPauseSetted;
        PauseManager.OnPauseUnsetted += onPauseUnsetted;
    }


    private void OnDisable()
    {
        OnPurchaseCompleted -= onPurchaseCompleted;



        PauseManager.OnPauseSetted -= onPauseSetted;
        PauseManager.OnPauseUnsetted -= onPauseUnsetted;
    }



    public void ShowTurretMultiplierText(string content)
    {
        turretSpeedMultiplierText.text = "Turret Speed Multiplier ($" + content + ")";
    }

    public void ShowTurretDistanceMultiplierText(string content)
    {
        turretDistanceMultipliertText.text = "Turret Distance Multiplier ($" + content + ")";
    }
    
    private void onPurchaseCompleted(PurchaseType type, string requiredContent, int price)
    {
        if (type == PurchaseType.TurretFireDelayMultiplier)
        {
            ShowTurretMultiplierText(requiredContent);

            Turret.FireDelayMultiplier += 0.2f;

            AsteroidSpawner.SpawnerMultiplier += 0.1f;

            pointsUI.UpdatePoints(false);
        }

        if (type == PurchaseType.TurretDistanceMultiplier)
        {
            ShowTurretDistanceMultiplierText(requiredContent);

            Turret.ShootMaxDistance += 0.2f;

            pointsUI.UpdatePoints(false);
        }
    }



    private void onPauseSetted()
    {
        shopPanel.SetActive(true);
    }

    private void onPauseUnsetted()
    {
        shopPanel.SetActive(false);
    }
}
