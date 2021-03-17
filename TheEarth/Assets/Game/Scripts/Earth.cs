using UnityEngine;
using UnityEngine.UI;



[RequireComponent(typeof(EarthChanger))]
[RequireComponent(typeof(Image))]
public class Earth : MonoBehaviour
{
    private EarthChanger changerEarth;



    private int currentEarthIndex => changerEarth.CurrentEarthIndex;



    public delegate void DamageTakeHandler(int currentIndex, int updatedIndex, ref bool allow);
    public delegate void EarthDeadHandler(int onIndex, ref bool allow);

    public event DamageTakeHandler OnDamageRequested;
    public event EarthDeadHandler OnDeadRequested;



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

        if (value >= 9)
        {
            bool allowDead = true;

            OnDeadRequested?.Invoke(value, ref allowDead);

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

    // gosha dudar is good
}
