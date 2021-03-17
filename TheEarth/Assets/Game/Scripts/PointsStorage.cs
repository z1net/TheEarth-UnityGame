using System;
using UnityEngine;



public class PointsStorage : MonoBehaviour
{
    private int points;



    public int Points => points;



    public event Action<int> OnPointsChanged;



    public void IncreasePoints(int value = 1)
    {
        points += value;

        OnPointsChanged?.Invoke(value);
    }

    public void DecreasePoints(int value)
    {
        points -= value;
    }
}
