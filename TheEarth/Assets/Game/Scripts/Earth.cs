using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(EarthChanger))]
[RequireComponent(typeof(Image))]
public class Earth : MonoBehaviour
{
    [SerializeField] private GameObject currentEarth => gameObject;

    private EarthChanger changerEarth;

    private int currentEarthIndex => changerEarth.CurrentEarthIndex;



    private void Start()
    {
        changerEarth = GetComponent<EarthChanger>();
    }

    public void DrawEarth(Sprite sprite)
    {
        gameObject.GetComponent<Image>().sprite = sprite;
    }

    public bool TakeDamage()
    {
        bool result = false;

        int value = currentEarthIndex + 1;

        bool allow = true;
        OnDamageRequested?.Invoke(currentEarthIndex, value, ref allow);

        if (!allow) { return result; }

        if (value >= 9) // earth is dead
        {
            bool allowDead = true;

            OnEarthDeadRequested?.Invoke(value, ref allowDead);

            if (!allowDead)
            {
                return result;
            }

            SceneHelper.Restart();
            return result;
        }

        if (value < 9)
        {
            result = true;

            changerEarth.ChangeEarth();
        }

        return result;
    }



    public delegate void DamageTakeHandler(int currentIndex, int updatedIndex, ref bool allow);
    public delegate void EarthDeadHandler(int onIndex, ref bool allow);



    public static event DamageTakeHandler OnDamageRequested;
    public static event EarthDeadHandler OnEarthDeadRequested;

    // gosha dudar is good
}
