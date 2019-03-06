using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {
    public GameObject[] hand;
    public Transform[] cardPos;
    private GameObject card1;
    public bool replaceCard;
    public GameObject spawner;
    private float repeat;

    private void Awake()
    {
        placeCard();
    }

    // Use this for initialization
    void Start()
    {
        replaceCard = true;
        repeat = Time.time;
       
        InvokeRepeating("placeCard", repeat, 5.0f);

    }

    // Update is called once per frame
    void Update () {
  
                 if (replaceCard == true)
        {
            CheckCard(hand[0], 0);
            CheckCard(hand[1], 1);
            CheckCard(hand[2], 2);
            CheckCard(hand[3], 3);
            CheckCard(hand[4], 4);
            replaceCard = false;
        }

	}

    private void CheckCard(GameObject card, int pos)
    {
        if (card == null)
        {
            card = Instantiate(gameObject.GetComponent<Deck>().topCard, cardPos[pos].transform.position, Quaternion.identity);
            hand[pos] = card;
            gameObject.GetComponent<Deck>().topCard = null;
            repeat = Time.time + 5.0f;
        }
    }
    void placeCard()
    {


        int i = 0;
        
        while (i <= 10 && gameObject.GetComponent<Deck>().topCard != null)
        {
            CheckCard(hand[i], i);
            i++;
        }
    }
}
