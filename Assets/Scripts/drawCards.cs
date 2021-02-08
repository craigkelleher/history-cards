using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Enable the Draw Cards button for the game
public class DrawCards : MonoBehaviour
{
    public GameObject Card1;
    public GameObject Card2;
    public GameObject OpponantArea;
    public GameObject PlayerArea;
    public Sprite[] cardArt; //array of card arts
    public GameObject spriteInserter;

    //create a private deck/list of cards
    List<GameObject> cards = new List<GameObject>();

    // deck list from card IDs
    int[] playerDeck = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
    int[] enemyDeck = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

    void Start()
    {
        //at beginning of game we will create a card list with card 1 and 2 in that list.
        cards.Add(Card1);
        cards.Add(Card2);

        //shuffle the array of cardIDs
        ShuffleDeck(playerDeck);
        ShuffleDeck(enemyDeck);
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
            // spriteInserter is used to insert the card art into the card based on the index of the playerDeck
            spriteInserter = playerCard.transform.Find("Image").gameObject;
            spriteInserter.GetComponent<Image>().sprite = cardArt[playerDeck[i]];
            playerCard.transform.SetParent(PlayerArea.transform, false);


            //week 5, give 5 cards to opponant area, instantiate at origin with no rotation
            GameObject enemyCard = Instantiate(cards[Random.Range(0, cards.Count)], new Vector3(0, 0, 0), Quaternion.identity);
            spriteInserter = enemyCard.transform.Find("Image").gameObject;
            spriteInserter.GetComponent<Image>().sprite = cardArt[enemyDeck[i]];
            enemyCard.transform.SetParent(OpponantArea.transform, false);
        }
    }

    void ShuffleDeck(int[] deck)
    {
        for (int i = 0; i < deck.Length; i++)
        {
            int tmp = deck[i];
            int r = Random.Range(i, deck.Length);
            deck[i] = deck[r];
            deck[r] = tmp;
        }
    }

}
