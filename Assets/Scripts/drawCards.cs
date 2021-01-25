using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enable the Draw Cards button for the game
public class DrawCards : MonoBehaviour
{
    public GameObject Card1;
    public GameObject Card2;
    public GameObject EnemyArea;
    public GameObject PlayerArea;

    void Start()
    {

    }

    // Inspired by Unity Tutorial - Drag & Drop Tutorial
    public void OnClick()
    {
        //if starting hand size if 5
        for (var i = 0; i < 6; i++)
        {
            // Make new player card and set it to the instantiation of new card, create an instance of card 1 public game object
            // Quarternion means no rotation on object at the moment
            GameObject playerCard = Instantiate(Card1, new Vector3(0, 0, 0), Quaternion.identity);
            // every game object in Unity has a property called transform, meaning where it should be/live, and we want to set its parent to be the player area transform
            // when we instnatiate this player card object, we want to set it as a child as player area game object. 
            playerCard.transform.SetParent(PlayerArea.transform, false);
        }

    }

}
