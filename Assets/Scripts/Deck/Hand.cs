using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {
    public List<GameObject> hand;
    public Transform[] cardPos;
    private GameObject card1;
    public bool Initialize;
    public GameObject spawner;
    private float repeat;

    // Use this for initialization
    void Start()
    {
        Initialize = true;
        
        InvokeRepeating("placeCard", Time.time, 5.0f);
    }

    // Update is called once per frame
    void Update () {
  
         if (Initialize == true)
        {
            InitializeHand();
            Initialize = false;
        }

	}

    private void InitializeHand()
    {
        for(int i = 0; i <=4; i++)
        {
            CheckCard(hand[i], i);
        }
    }

    private void CheckCard(GameObject card, int pos)
    {
        
        if (card == null)
        {
            hand.Insert(pos, Instantiate(gameObject.GetComponent<Deck>().topCard, cardPos[pos].transform.position, Quaternion.identity));
            gameObject.GetComponent<Deck>().topCard = null;
        }
    }
    void placeCard()
    {
        int i = 0;
        
        while (i <= 9 && gameObject.GetComponent<Deck>().topCard != null)
        {
            CheckCard(hand[i], i);
            i++;
        }
    }
}
