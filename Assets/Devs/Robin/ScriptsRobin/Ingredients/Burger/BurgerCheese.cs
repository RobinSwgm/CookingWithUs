using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerCheese : BurgerMain
{
    [SerializeField] GameObject BurgerCheesePrefab;

    public static bool iscreated;

    protected override void AdjustedSpawnPoint()
    {
        if (!iscreated)
        {
            Vector3 adjustedSpawnPosition = _spawn.position + new Vector3(0f, 0.48f, 0f);
            GameObject burgercheeseObj = Instantiate(BurgerCheesePrefab, adjustedSpawnPosition, Quaternion.identity, _parentRightHand.transform);
            playerScript.currentItems.Add(burgercheeseObj);
            burgercheeseObj.transform.localScale = new Vector3(100, 80f, 100f);

            iscreated = true;
        }
    }
}
