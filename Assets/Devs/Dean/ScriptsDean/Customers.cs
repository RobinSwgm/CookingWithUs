using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customers : MonoBehaviour
{
    [SerializeField] private Tickets ticketScript;
    private PlayerMovement playerScript;

    public int amountOfCorrectIngredients = 0;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerScript = other.GetComponent<PlayerMovement>();
            if (playerScript.grab.action.inProgress && playerScript.hasCooked)
            {
                if(playerScript.currentItems.Count > 0 && ticketScript.pizzaTickets.Count > 0 && ticketScript.pizzaTickets[0].Count == playerScript.currentItems.Count)
                {
                    for (int i = 0; i < playerScript.currentItems.Count; i++)
                    {
                        if (i < ticketScript.pizzaTickets[0].Count)
                        {
                            if (playerScript.currentItems[i].name == ticketScript.pizzaTickets[0][i].name)
                            {
                                Debug.Log("Correct!");
                                amountOfCorrectIngredients++;
                                if (amountOfCorrectIngredients == ticketScript.pizzaTickets[0].Count)
                                {
                                    for (int j = playerScript.currentItems.Count - 1; j >= 0; j--)
                                    {
                                        Destroy(playerScript.currentItems[j]);
                                        playerScript.currentItems.RemoveAt(j);
                                    }
                                    ticketScript.DeletePizzaTicket(0);
                                    playerScript.ResetPizzaIngredients();
                                    playerScript.hasCooked = false;
                                }
                            }
                        }
                    }
                    amountOfCorrectIngredients = 0;
                }

                if (playerScript.currentItems.Count > 0 && ticketScript.burgerTickets.Count > 0 && ticketScript.burgerTickets[0].Count == playerScript.currentItems.Count)
                {
                    for (int i = 0; i < playerScript.currentItems.Count; i++)
                    {
                        if (i < ticketScript.burgerTickets[0].Count)
                        {
                            if (playerScript.currentItems[i].name == ticketScript.burgerTickets[0][i].name)
                            {
                                amountOfCorrectIngredients++;
                                if (amountOfCorrectIngredients == ticketScript.burgerTickets[0].Count)
                                {
                                    for (int j = playerScript.currentItems.Count - 1; j >= 0; j--)
                                    {
                                        Destroy(playerScript.currentItems[j]);
                                        playerScript.currentItems.RemoveAt(j);
                                    }
                                    ticketScript.DeleteBurgerTicket(0);
                                    playerScript.ResetBurgerIngredients();
                                    playerScript.hasCooked = false;
                                }
                            }
                        }
                    }
                    amountOfCorrectIngredients = 0;
                }
            }
        }
    }
}
