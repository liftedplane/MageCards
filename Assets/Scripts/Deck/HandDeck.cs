using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HandDeck : MonoBehaviour
{
    public GameObject[] deck;
    public Transform[] cardPos;

    int randomInt;
    int cardLoc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            SpawnRandomCard();
        }   
    }
    //spawning random cards to place on field
    void SpawnRandomCard()
    {
        randomInt = Random.Range(0, deck.Length);
        cardLoc = System.Array.IndexOf(cardPos, deck);
        Instantiate(deck[randomInt], cardPos[cardLoc].position, cardPos[cardLoc].rotation);
    }
}
