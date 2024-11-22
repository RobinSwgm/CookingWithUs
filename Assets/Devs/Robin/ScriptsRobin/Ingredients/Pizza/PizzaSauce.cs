using UnityEngine;

public class PizzaSauce : PizzaMain
{
    [SerializeField] GameObject pizzaSaucePrefab;

    public static bool iscreated;

    protected override void AdjustedSpawnPoint()
    {
        if (!iscreated)
        {
            Vector3 adjustedSpawnPosition = _spawn.position + new Vector3(0f, 0.04f, 0f);
            GameObject sauceObj = Instantiate(pizzaSaucePrefab, adjustedSpawnPosition, Quaternion.identity, _parentRightHand.transform);
            playerScript.currentItems.Add(sauceObj);
            iscreated = true;
        }

    }

}
