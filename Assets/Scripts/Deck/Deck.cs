using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {
    public  GameObject topCard;
    public GameObject monCard1;
    public GameObject monCard2;
    public GameObject magCard1;
    public GameObject magCard2;
    private float randSet;
	// Use this for initialization
	void Start () {
        topCard = null;
	}
	
	// Update is called once per frame
	void Update () {
        if (topCard == null)
        {
            setRandTopCard();
        }
	}
    private void setRandTopCard()
    {
        randSet = Random.Range(0.0f, 100.0f);
        if (randSet <= 30.0f)
        {
            topCard = monCard1;
        }
        else if (randSet >= 30.1f && randSet <= 60.0f)
        {
            topCard = monCard2;
        }
        else if (randSet >= 60.1f && randSet <= 80.0f)
        {
            topCard = magCard1;
        }
        else if (randSet >= 80.1f && randSet <= 100.0f)
        {
            topCard = magCard2;
        }
    }
}
