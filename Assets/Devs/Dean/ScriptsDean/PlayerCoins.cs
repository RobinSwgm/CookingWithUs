using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCoins : MonoBehaviour
{
    public int amountOfCoins = 100;
    public int coinDecreaseTime = 1;

    [SerializeField] TextMeshProUGUI playerCoins;

    private void Start()
    {
        StartCoroutine(CoinDescrease());
    }

    private void Update()
    {
        playerCoins.text = amountOfCoins.ToString();
    }

    private IEnumerator CoinDescrease()
    {
        yield return new WaitForSeconds(coinDecreaseTime);
        amountOfCoins--;
        if(amountOfCoins == 0)
        {
            Debug.Log("You ran out of money!!!");
        }
        else
        {
            StartCoroutine(CoinDescrease());
        }
    }
}
