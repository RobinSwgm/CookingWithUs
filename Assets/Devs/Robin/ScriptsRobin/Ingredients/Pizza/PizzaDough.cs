using UnityEngine;

public class PizzaDough : PizzaMain
{
    [SerializeField] GameObject pizzaDoughPrefab;

    public static bool iscreated;

    protected override void AdjustedSpawnPoint()
    {
        if (!iscreated)
        {
            GameObject doughObj = Instantiate(pizzaDoughPrefab, _spawn.position, Quaternion.identity, _parentRightHand.transform);
            playerScript.currentItems.Add(doughObj);
            iscreated = true;
        }
    }
}
