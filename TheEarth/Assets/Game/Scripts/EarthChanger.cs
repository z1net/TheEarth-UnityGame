using UnityEngine;



[RequireComponent(typeof(Earth))]
public class EarthChanger : MonoBehaviour
{
    [SerializeField] private Sprite[] earthTypes = new Sprite[9];



    private Earth earth;



    public int CurrentEarthIndex { get; private set; }



    public delegate void OnEarthChangeHandler(Sprite toSprite, ref bool allow);

    public static event OnEarthChangeHandler OnEarthChangeRequested;



    private void Start()
    {
        earth = GetComponent<Earth>();

        CurrentEarthIndex = 1;
    }



    public void ChangeEarth()
    {
        bool allow = true;

        int value = CurrentEarthIndex + 1;

        Sprite sprite = earthTypes[value];

        OnEarthChangeRequested?.Invoke(sprite, ref allow);
        if (allow == false) { return; }

        CurrentEarthIndex += 1;
        earth.DrawEarth(sprite);
    }
}
