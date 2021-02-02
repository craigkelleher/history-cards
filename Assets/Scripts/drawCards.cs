using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enable the Draw Cards button for the game
public class DrawCards : MonoBehaviour
{
    public GameObject Card1;
    public GameObject Card2;
    public GameObject OpponantArea;
    public GameObject PlayerArea;

    //create a private deck/list of cards
    List<GameObject> cards = new List<GameObject>();


    void Start()
    {
        //at beginning of game we will create a card list with card 1 and 2 in that list.
        cards.Add(Card1);
        cards.Add(Card2);
    }

    // Inspired by Unity Tutorial - Drag & Drop Tutorial
    public void OnClick()
    {
        //if starting hand size if 5
        for (var i = 0; i < 6; i++)
        {
            // Make new player card and set it to the instantiation of new card, create an instance of card 1 public game object
            // Quarternion means no rotation on object at the moment
            // change card instnatiatate to be random, instead of same card.
             // select random number in the list, with the range being between 0 and number of things in that list.
            GameObject playerCard = Instantiate(cards[Random.Range(0, cards.Count)], new Vector3(0, 0, 0), Quaternion.identity);
            // every game object in Unity has a property called transform, meaning where it should be/live, and we want to set its parent to be the player area transform
            // when we instnatiate this player card object, we want to set it as a child as player area game object. 
            playerCard.transform.SetParent(PlayerArea.transform, false);


            //week 5, give 5 cards to opponant area, instantiate at origin with no rotation
            GameObject enemyCard = Instantiate(cards[Random.Range(0, cards.Count)], new Vector3(0, 0, 0), Quaternion.identity);
            enemyCard.transform.SetParent(OpponantArea.transform, false);
        }

    }

}
