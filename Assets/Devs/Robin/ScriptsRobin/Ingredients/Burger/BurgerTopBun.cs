using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerTopBun : BurgerMain
{
    [SerializeField] GameObject TopBunBurgerPrefab;

    public static bool iscreated;

    protected override void AdjustedSpawnPoint()
    {
        if (!iscreated)
        {
            Vector3 adjustedSpawnPosition = _spawn.position + new Vector3(0f, 0.22f * playerScript.currentItems.Count, 0f);
            GameObject topbunObj = Instantiate(TopBunBurgerPrefab, adjustedSpawnPosition, Quaternion.identity, _parentRightHand.transform);
            playerScript.currentItems.Add(topbunObj);
            iscreated = true;
        }
    }
}
