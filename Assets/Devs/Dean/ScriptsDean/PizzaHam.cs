using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaHam : PizzaMain
{
    [SerializeField] GameObject pizzaHamPrefab;

    public static bool iscreated;
    protected override void AdjustedSpawnPoint()
    {
        if (!iscreated)
        {
            Vector3 adjustedSpawnPosition = _spawn.position + new Vector3(0f, 0.04f * playerScript.currentItems.Count, 0f);
            GameObject sauceObj = Instantiate(pizzaHamPrefab, adjustedSpawnPosition, Quaternion.identity, _parentRightHand.transform);
            playerScript.currentItems.Add(sauceObj);
            iscreated = true;
        }
    }
}
