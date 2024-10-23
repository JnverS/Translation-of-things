using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] List<Transform> availablePlaces = new List<Transform>();
    [SerializeField] Transform itemPlaces;
    void Start()
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
            Transform spawnPosition = availablePlaces[0];
            availablePlaces.RemoveAt(0); 
            return spawnPosition;
        }
        return null;
    }
}
