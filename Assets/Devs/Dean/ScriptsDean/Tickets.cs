using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tickets : MonoBehaviour
{
    [SerializeField] private AudioSource SFXSource;
    public GameObject burgerBottomBun;
    public GameObject burgerTopBun;
    public List<GameObject> burgerIngredientList;
    public Transform burgerSpawnLocation;
    public float burgerYOffset = -100f;
    public float burgerInitialOffset = -50f;
    public float burgerXOffset = 200f;
    public int maxBurgerTickets = 3;
    public int amountOfBurgerTickets = 0;
    public int amountOfCoinsForBurgerTicket = 10;
    [SerializeField] private AudioClip burgerTicketFinishedSFX;
    public List<List<GameObject>> burgerTickets = new List<List<GameObject>>();
    public int burgerTicketsCompleted;

    public GameObject pizzaDough;
    public GameObject pizzaSauce;
    public List<GameObject> pizzaIngredientList;
    public Transform pizzaSpawnLocation;
    public float pizzaYOffset = 100f;
    public float pizzaInitialOffset = 50f;
    public float pizzaXOffset = 200f;
    public int maxPizzaTickets = 3;
    public int amountOfPizzaTickets = 0;
    public int amountOfCoinsForPizzaTicket = 10;
    [SerializeField] private AudioClip pizzaTicketFinishedSFX;
    public List<List<GameObject>> pizzaTickets = new List<List<GameObject>>();
    public int pizzaTicketsCompleted;

    [SerializeField] private PlayerCoins coinsScript;

    private void Start()
    {
        StartCoroutine(NewPizzaTicket());
        StartCoroutine(NewBurgerTicket());
    }

    private IEnumerator NewPizzaTicket()
    {
        yield return new WaitForSeconds(11 - coinsScript.player1Difficulty);
        maxPizzaTickets = 2 + coinsScript.player1Difficulty;
        UpdatePizzaTickets();
        StartCoroutine(NewPizzaTicket());
    }

    private IEnumerator NewBurgerTicket()
    {
        yield return new WaitForSeconds(11 - coinsScript.player2Difficulty);
        maxBurgerTickets = 2 + coinsScript.player2Difficulty;
        UpdateBurgerTickets();
        StartCoroutine(NewBurgerTicket());
    }

    private List<GameObject> CreateBurgerTicket()
    {
        List<GameObject> newTicket = new List<GameObject>();
        GameObject topBun = Instantiate(burgerTopBun, burgerSpawnLocation);
        newTicket.Add(topBun);
        int size = coinsScript.player2Difficulty;
        for (int i = 0; i < size; i++)
        {
            GameObject ingredient = Instantiate(burgerIngredientList[i], burgerSpawnLocation);
            newTicket.Add(ingredient);
        }
        GameObject bottomBun = Instantiate(burgerBottomBun, burgerSpawnLocation);
        newTicket.Add(bottomBun);
        amountOfBurgerTickets++;

        return newTicket;
    }

    public void UpdateBurgerTickets()
    {
        if (amountOfBurgerTickets < maxBurgerTickets)
        {
            List<GameObject> ticket = CreateBurgerTicket();
            burgerTickets.Add(ticket);

            for (int i = 0; i < ticket.Count; i++)
            {
                ticket[i].transform.localPosition = new Vector3((burgerTickets.Count - 1) * burgerXOffset, i * burgerYOffset + burgerInitialOffset, 0);
            }
            StartCoroutine(BurgerCoinsOverTime());
        }
    }

    private List<GameObject> CreatePizzaTicket()
    {
        List<GameObject> newTicket = new List<GameObject>();
        GameObject dough = Instantiate(pizzaDough, pizzaSpawnLocation);
        GameObject sauce = Instantiate(pizzaSauce, pizzaSpawnLocation);
        newTicket.Add(dough);
        newTicket.Add(sauce);
        int size = coinsScript.player1Difficulty;
        for (int i = 0; i < size; i++)
        {
            GameObject topping = Instantiate(pizzaIngredientList[i], pizzaSpawnLocation);
            newTicket.Add(topping);
        }
        amountOfPizzaTickets++;

        return newTicket;
    }

    public void UpdatePizzaTickets()
    {
        if (amountOfPizzaTickets < maxPizzaTickets)
        {
            List<GameObject> ticket = CreatePizzaTicket();
            pizzaTickets.Add(ticket);

            for (int i = 0; i < ticket.Count; i++)
            {
                ticket[i].transform.localPosition = new Vector3((pizzaTickets.Count - 1) * pizzaXOffset, i * pizzaYOffset + pizzaInitialOffset, 0);
            }
        }
        StartCoroutine(PizzaCoinsOverTime());
    }

    public void DeleteBurgerTicket(int index)
    {
        if (index >= 0 && index < burgerTickets.Count)
        {
            List<GameObject> ticketToRemove = burgerTickets[index];
            foreach (GameObject ingredient in ticketToRemove)
            {
                Destroy(ingredient);
            }
            SFXSource.PlayOneShot(burgerTicketFinishedSFX);

            burgerTickets.RemoveAt(index);
            RearrangeBurgerTickets();
            amountOfBurgerTickets--;
            coinsScript.player2AmountOfCoins += amountOfCoinsForBurgerTicket * coinsScript.player2Difficulty;
            burgerTicketsCompleted++;
            if (burgerTicketsCompleted == 3)
            {
                coinsScript.player2Difficulty++;
            }
            if (burgerTicketsCompleted == 7)
            {
                coinsScript.player2Difficulty++;
            }
        }
    }

    public void DeletePizzaTicket(int index)
    {
        if (index >= 0 && index < pizzaTickets.Count)
        {
            List<GameObject> ticketToRemove = pizzaTickets[index];
            foreach (GameObject ingredient in ticketToRemove)
            {
                Destroy(ingredient);
            }
            SFXSource.PlayOneShot(pizzaTicketFinishedSFX);

            pizzaTickets.RemoveAt(index);
            RearrangePizzaTickets();
            amountOfPizzaTickets--;
            coinsScript.player1AmountOfCoins += amountOfCoinsForPizzaTicket * coinsScript.player1Difficulty;
            pizzaTicketsCompleted++;
            if (pizzaTicketsCompleted == 3)
            {
                coinsScript.player1Difficulty++;
            }
            if (pizzaTicketsCompleted == 7)
            {
                coinsScript.player1Difficulty++;
            }
        }
    }

    private void RearrangeBurgerTickets()
    {
        for (int ticketIndex = 0; ticketIndex < burgerTickets.Count; ticketIndex++)
        {
            List<GameObject> ticket = burgerTickets[ticketIndex];
            for (int i = 0; i < ticket.Count; i++)
            {
                ticket[i].transform.localPosition = new Vector3(ticketIndex * burgerXOffset, i * burgerYOffset + burgerInitialOffset, 0);
            }
        }
    }

    private void RearrangePizzaTickets()
    {
        for (int ticketIndex = 0; ticketIndex < pizzaTickets.Count; ticketIndex++)
        {
            List<GameObject> ticket = pizzaTickets[ticketIndex];
            for (int i = 0; i < ticket.Count; i++)
            {
                ticket[i].transform.localPosition = new Vector3(ticketIndex * pizzaXOffset, i * pizzaYOffset + pizzaInitialOffset, 0);
            }
        }
    }

    private IEnumerator BurgerCoinsOverTime()
    {
        yield return new WaitForSeconds(1);
        if (amountOfCoinsForBurgerTicket > 0)
        {
            amountOfCoinsForBurgerTicket--;
        }
    }

    private IEnumerator PizzaCoinsOverTime()
    {
        yield return new WaitForSeconds(1);
        if (amountOfCoinsForPizzaTicket > 0)
        {
            amountOfCoinsForPizzaTicket--;
        }
    }
}
