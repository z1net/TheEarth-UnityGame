using System;
using UnityEngine;



[RequireComponent(typeof(PointsStorage))]
[RequireComponent(typeof(EarthShopUI))]
public class EarthShop : MonoBehaviour
{
    private int turretFireDelayMultiplierPrice;

    private int turretDistanceMultiplierPrice;

    private EarthShopUI shopUI;

    private PointsStorage storage;



    /*public delegate void OnPurchaseCompletedSuccessfullyHandler(PurchaseType type, string requiredContent, int price);

    public static event OnPurchaseCompletedSuccessfullyHandler OnPurchaseCompleted;*/

    public event Action<PurchaseType, string, int> OnPurchaseCompleted;



    private void Start()
    {
        shopUI = GetComponent<EarthShopUI>();

        storage = GetComponent<PointsStorage>();

        turretFireDelayMultiplierPrice = getRandomValue(1, 2);
        turretDistanceMultiplierPrice = getRandomValue(1, 2);

        shopUI.ShowTurretMultiplierText(turretFireDelayMultiplierPrice.ToString());
        shopUI.ShowTurretDistanceMultiplierText(turretDistanceMultiplierPrice.ToString());
    }

    private int getRandomValue(int min = 1, int max = 30)
    {
        return UnityEngine.Random.Range(min, max);
    }

    public void BuyTurretMultiplier()
    {
        if (storage.Points >= turretFireDelayMultiplierPrice)
        {
            int price = turretFireDelayMultiplierPrice;

            storage.DecreasePoints(price);
            turretFireDelayMultiplierPrice += price;

            OnPurchaseCompleted?.Invoke(PurchaseType.TurretFireDelayMultiplier, turretFireDelayMultiplierPrice.ToString(), price);
        }
    }

    public void BuyTurretDistanceMultiplier()
    {
        if (storage.Points >= turretDistanceMultiplierPrice)
        {
            int price = turretDistanceMultiplierPrice;

            storage.DecreasePoints(price);
            turretDistanceMultiplierPrice += price;

            OnPurchaseCompleted?.Invoke(PurchaseType.TurretDistanceMultiplier, turretDistanceMultiplierPrice.ToString(), price);
        }
    }

    public enum PurchaseType
    {
        None,
        TurretFireDelayMultiplier,
        TurretDistanceMultiplier,
    }
}
