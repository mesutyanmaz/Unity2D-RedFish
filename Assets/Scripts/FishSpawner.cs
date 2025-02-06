using UnityEngine;
using System;

public class FishSpawner : MonoBehaviour
{

    [SerializeField]
    private Fish fishPrefab;

    [SerializeField]
    private Fish.FishType[] fishTypes;


    private void Awake()
    {
        for (int i = 0; i < fishTypes.Length; i++) //length of array
        {
            int num = 0;
            while (num < fishTypes[i].fishCount)
            {
                Fish fish = UnityEngine.Object.Instantiate<Fish>(fishPrefab); //to create a new one
                fish.Type = fishTypes[i];
                fish.ResetFish();
                num++;
            }
        }

    }

}
