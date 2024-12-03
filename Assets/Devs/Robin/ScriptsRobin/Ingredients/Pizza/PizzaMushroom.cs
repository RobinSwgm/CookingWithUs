using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaMushroom : PizzaMain
{
    [SerializeField] GameObject pizzaMushroomPrefab;

    public static bool iscreated;

    protected override void AdjustedSpawnPoint()
    {
        if (!iscreated)
        {
            Vector3 adjustedSpawnPosition = _spawn.position + new Vector3(0f, 0.08f, 0f);
            GameObject mushroomObj = Instantiate(pizzaMushroomPrefab, adjustedSpawnPosition, Quaternion.identity, _parentRightHand.transform);
            playerScript.currentItems.Add(mushroomObj);
            iscreated = true;
        }
    }
}
