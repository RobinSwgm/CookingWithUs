using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tickets : MonoBehaviour
{
    public GameObject burgerBottomBun;
    public GameObject burgerTopBun;
    public List<GameObject> burgerIngredientList;
    public Transform burgerSpawnLocation;
    public float burgerYOffset = -100f;
    public float burgerInitialOffset = -50f;
    public float burgerXOffset = 200f;
    public int maxBurgerTickets = 3;
    public int amountOfBurgerTickets = 0;

    public GameObject pizzaDough;
    public GameObject pizzaSauce;
    public List<GameObject> pizzaIngredientList;
    public Transform pizzaSpawnLocation;
    public float pizzaYOffset = 100f;
    public float pizzaInitialOffset = 50f;
    public float pizzaXOffset = 200f;
    public int maxPizzaTickets = 3;

    public int difficulty = 1;

    private List<List<GameObject>> burgerTickets = new List<List<GameObject>>();
    private List<List<GameObject>> pizzaTickets = new List<List<GameObject>>();

    private void Start()
    {
        UpdateBurgerTickets();
        UpdatePizzaTickets();
        StartCoroutine(Test());
    }

    private IEnumerator Test()
    {
        yield return new WaitForSeconds(5);
        DeleteBurgerTicket(1);
    }

    private List<GameObject> CreateBurgerTicket()
    {
        List<GameObject> newTicket = new List<GameObject>();
        GameObject topBun = Instantiate(burgerTopBun, burgerSpawnLocation);
        newTicket.Add(topBun);
        int size = Random.Range(1, difficulty + 1);
        for (int i = 0; i < size; i++)
        {
            int choice = Random.Range(0, burgerIngredientList.Count);
            GameObject ingredient = Instantiate(burgerIngredientList[choice], burgerSpawnLocation);
            newTicket.Add(ingredient);
        }
        GameObject bottomBun = Instantiate(burgerBottomBun, burgerSpawnLocation);
        newTicket.Add(bottomBun);

        return newTicket;
    }

    private void UpdateBurgerTickets()
    {
        if (amountOfBurgerTickets < maxBurgerTickets)
        {

        }
        for (int ticketIndex = 0; ticketIndex < maxBurgerTickets; ticketIndex++)
        {
            List<GameObject> ticket = CreateBurgerTicket();
            burgerTickets.Add(ticket);

            for (int i = 0; i < ticket.Count; i++)
            {
                ticket[i].transform.localPosition = new Vector3(
                    ticketIndex * burgerXOffset,
                    i * burgerYOffset + burgerInitialOffset,
                    0
                );
            }
        }
    }

    private List<GameObject> CreatePizzaTicket()
    {
        List<GameObject> newTicket = new List<GameObject>();
        GameObject dough = Instantiate(pizzaDough, pizzaSpawnLocation);
        GameObject sauce = Instantiate(pizzaSauce, pizzaSpawnLocation);
        newTicket.Add(dough);
        newTicket.Add(sauce);
        int size = Random.Range(1, difficulty + 1);
        for (int i = 0; i < size; i++)
        {
            int choice = Random.Range(0, pizzaIngredientList.Count);
            GameObject topping = Instantiate(pizzaIngredientList[choice], pizzaSpawnLocation);
            newTicket.Add(topping);
        }

        return newTicket;
    }

    private void UpdatePizzaTickets()
    {
        for (int ticketIndex = 0; ticketIndex < maxPizzaTickets; ticketIndex++)
        {
            List<GameObject> ticket = CreatePizzaTicket();
            pizzaTickets.Add(ticket);

            for (int i = 0; i < ticket.Count; i++)
            {
                ticket[i].transform.localPosition = new Vector3(
                    ticketIndex * pizzaXOffset,
                    i * pizzaYOffset + pizzaInitialOffset,
                    0
                );
            }
        }
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
            burgerTickets.RemoveAt(index);
            RearrangeBurgerTickets();
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
            pizzaTickets.RemoveAt(index);
            RearrangePizzaTickets();
        }
    }

    private void RearrangeBurgerTickets()
    {
        for (int ticketIndex = 0; ticketIndex < burgerTickets.Count; ticketIndex++)
        {
            List<GameObject> ticket = burgerTickets[ticketIndex];
            for (int i = 0; i < ticket.Count; i++)
            {
                ticket[i].transform.localPosition = new Vector3(
                    ticketIndex * burgerXOffset,
                    i * burgerYOffset + burgerInitialOffset,
                    0
                );
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
                ticket[i].transform.localPosition = new Vector3(
                    ticketIndex * pizzaXOffset,
                    i * pizzaYOffset + pizzaInitialOffset,
                    0
                );
            }
        }
    }
}