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
            Vector3 adjustedSpawnPosition = _spawn.position + new Vector3(0f, 0.65f, 0f);
            GameObject topbunObj = Instantiate(TopBunBurgerPrefab, adjustedSpawnPosition, Quaternion.identity, _parentRightHand.transform);
            topbunObj.transform.localScale = new Vector3(80, 80f, 80f);
            playerScript.currentItems.Add(topbunObj);
            iscreated = true;
        }
    }
}
