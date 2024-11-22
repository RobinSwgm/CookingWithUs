using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCoins : MonoBehaviour
{
    public int player1AmountOfCoins = 100;
    [SerializeField] private TextMeshProUGUI player1Coins;
    [SerializeField] private GameObject player1Lost;
    public int player1Difficulty = 1;

    public int player2AmountOfCoins = 100;
    [SerializeField] private TextMeshProUGUI player2Coins;
    [SerializeField] private GameObject player2Lost;
    public int player2Difficulty = 1;

    public bool GameOver = false;

    private void Start()
    {
        StartCoroutine(Player1CoinDescrease());
        StartCoroutine(Player2CoinDescrease());
        player1Lost.SetActive(false);
        player2Lost.SetActive(false);
    }

    private void Update()
    {
        player1Coins.text = player1AmountOfCoins.ToString();
        player2Coins.text = player2AmountOfCoins.ToString();
    }

    private IEnumerator Player1CoinDescrease()
    {
        if (!GameOver)
        {
            yield return new WaitForSeconds(1 / player1Difficulty);
            player1AmountOfCoins--;
            if (player1AmountOfCoins <= 0)
            {
                player1Lost.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                StartCoroutine(Player1CoinDescrease());
            }
        }
    }

    private IEnumerator Player2CoinDescrease()
    {
        if (!GameOver)
        {
            yield return new WaitForSeconds(1 / player2Difficulty);
            player2AmountOfCoins--;
            if (player2AmountOfCoins <= 0)
            {
                player2Lost.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                StartCoroutine(Player2CoinDescrease());
            }
        }
    }
}
