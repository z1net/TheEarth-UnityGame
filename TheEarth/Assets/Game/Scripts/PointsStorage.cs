using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsStorage : MonoBehaviour
{
    private int points;

    public int Points => points;



    public void IncreasePoints(int value = 1)
    {
        points += value;

        OnPointsChanged?.Invoke(value);
    }

    public void DecreasePoints(int value)
    {
        points -= value;
    }



    public delegate void PointsChangedHandler(int addedValue);



    public static event PointsChangedHandler OnPointsChanged;
}
