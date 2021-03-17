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

    [SerializeField] private Turret turret;

    [SerializeField] private PauseManager pauseManager;

    [SerializeField] private AsteroidSpawner spawner;

    [SerializeField] private EarthShop shop;



    private PointsStorage storage;

    private PointsUI pointsUI;



    private void Start()
    {
        storage = GetComponent<PointsStorage>();

        pointsUI = GetComponent<PointsUI>();
    }



    private void OnEnable()
    {
        shop.OnPurchaseCompleted += onPurchaseCompleted;



        pauseManager.OnPauseSetted += onPauseSetted;
        pauseManager.OnPauseUnsetted += onPauseUnsetted;
    }


    private void OnDisable()
    {
        shop.OnPurchaseCompleted -= onPurchaseCompleted;



        pauseManager.OnPauseSetted -= onPauseSetted;
        pauseManager.OnPauseUnsetted -= onPauseUnsetted;
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

            turret.FireDelayMultiplier += 0.2f;

            spawner.SpawnerMultiplier += 0.1f;

            pointsUI.UpdatePoints(false);
        }

        if (type == PurchaseType.TurretDistanceMultiplier)
        {
            ShowTurretDistanceMultiplierText(requiredContent);

            turret.ShootMaxDistance += 0.2f;

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
