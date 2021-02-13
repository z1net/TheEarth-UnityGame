using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Earth))]
public class EarthChanger : MonoBehaviour
{
    [SerializeField] private Sprite[] earthTypes = new Sprite[9];

    public int CurrentEarthIndex { get; private set; }

    private Earth earth;



    private void Start()
    {
        CurrentEarthIndex = 1;

        earth = GetComponent<Earth>();
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

    

    public delegate void OnEarthChangeHandler(Sprite toSprite, ref bool allow);

    public static event OnEarthChangeHandler OnEarthChangeRequested;
}
