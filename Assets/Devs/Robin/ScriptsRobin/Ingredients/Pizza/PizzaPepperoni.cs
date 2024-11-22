using UnityEngine;

public class PizzaPepperoni : PizzaMain
{
    [SerializeField] GameObject pizzaPepperoniPrefab;


    public static bool iscreated;


    protected override void AdjustedSpawnPoint()
    {
        if (!iscreated)
        {
            Vector3 adjustedSpawnPosition = _spawn.position + new Vector3(0f, 0.08f, 0f);
            GameObject pepperoniObj = Instantiate(pizzaPepperoniPrefab, adjustedSpawnPosition, Quaternion.identity, _parentRightHand.transform);
            playerScript.currentItems.Add(pepperoniObj);
            iscreated = true;
        }
    }

}
