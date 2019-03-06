using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    private Hand playerHand;
    public static GameObject myCurrentObject = null;
    public static GameObject currCard;
    //Raycast var
    private Vector3 mousePos;
    private Vector2 mouseLocForRay;
    private RaycastHit2D HitOBject;
    private LayerMask layerMask;

    private void Start()
    {
        playerHand = this.GetComponent<Hand>();
        layerMask = LayerMask.GetMask("Cards");
    }

    private void LateUpdate()
    {
        //prep for Deck/Hand card destruction
        if (myCurrentObject == null && currCard != null)
        {
            playerHand.hand.RemoveAt(playerHand.hand.IndexOf(currCard));
            Destroy(currCard);
            //move cards
            for (int i = 0; i <= 9; i++)
            {
                playerHand.hand[i].transform.position = (playerHand.cardPos[i].position);
            }
        }
    }

    private void Update()
    {
        //track mouse position
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = -0.2f;
        if (Input.GetMouseButtonDown(0))
        {
            //Raycast
            mouseLocForRay = new Vector2(mousePos.x, mousePos.y);
            HitOBject = Physics2D.Raycast(mouseLocForRay, Vector2.zero, 1.0f, layerMask);
            if (HitOBject.collider == true)
            {
                myCurrentObject = HitOBject.collider.GetComponent<SummonInfo>().Prefab.gameObject; 
                currCard = HitOBject.collider.gameObject;
            }
        }
    }

    public static void Discard()
    {
        myCurrentObject = null;
        Destroy(currCard);
        currCard = null;
    }
}