using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerTomato : BurgerMain
{
    [SerializeField] GameObject BurgerTomatoPrefab;

    public static bool iscreated;

    protected override void AdjustedSpawnPoint()
    {
        if (!iscreated)
        {
            Vector3 adjustedSpawnPosition = _spawn.position + new Vector3(0f, 0.22f * playerScript.currentItems.Count, 0f);
            GameObject burgertomatoObj = Instantiate(BurgerTomatoPrefab, adjustedSpawnPosition, Quaternion.identity, _parentRightHand.transform);
            playerScript.currentItems.Add(burgertomatoObj);

            iscreated = true;
        }
    }
}
