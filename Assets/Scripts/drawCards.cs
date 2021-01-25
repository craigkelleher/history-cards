using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Enable the Draw Cards button for the game
public class drawCards : MonoBehaviour
{
    public GameObject Card1;
    public GameObject Card2;
    public GameObject EnemyArea;
    public GameObject PlayerArea;

    void Start()
    {

    }

    public void OnClick()
    {
        GameObject playerCard = Instantiate(Card1, new Vector3);
    }

}
