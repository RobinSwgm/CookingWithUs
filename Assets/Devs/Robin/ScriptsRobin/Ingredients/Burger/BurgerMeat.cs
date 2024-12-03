using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerMeat : BurgerMain
{
    [SerializeField] GameObject BurgerMeatPrefab;

    public static bool iscreated;

    protected override void AdjustedSpawnPoint()
    {
        if (!iscreated)
        {
            Vector3 adjustedSpawnPosition = _spawn.position + new Vector3(0f, 0.22f, 0f);
            GameObject burgermeatObj = Instantiate(BurgerMeatPrefab, adjustedSpawnPosition, Quaternion.identity, _parentRightHand.transform);
            playerScript.currentItems.Add(burgermeatObj);
            burgermeatObj.transform.localScale = new Vector3(50, 40f, 50f);

            iscreated = true;
        }
    }
}