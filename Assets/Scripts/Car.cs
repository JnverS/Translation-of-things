using System;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] List<Transform> availablePlaces = new List<Transform>();
    [SerializeField] Transform itemPlaces;
    void Start()
    {
        InitializeAvailablePlaces();
    }

    private void InitializeAvailablePlaces()
    {
        for (int i = 0; i < itemPlaces.childCount; i++)
        {
            availablePlaces.Add(itemPlaces.transform.GetChild(i));
        }
    }

    public Transform GetFreePlace()
    {
        if (availablePlaces.Count > 0)
        {
            Transform freePlace = availablePlaces[0];
            availablePlaces.RemoveAt(0);
            return freePlace;
        }
        return null;
    }
}
