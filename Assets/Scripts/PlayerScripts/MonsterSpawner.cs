using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monPrefab;
    public static GameObject myCurrentObject = null;
    public static GameObject currCard;
    private Vector3 mousePos;
    private Vector2 mouseLocForRay;
    private RaycastHit2D HitOBject;
    private GameObject card;
    private void Start()
    {

    }
    private void FixedUpdate()
    {
        //prep for Deck/Hand card destruction
        if (myCurrentObject == null && currCard != null)
        {
            Destroy(currCard);
        }
    }
    private void Update()
    {
        //card.transform.position = mousePos;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = -0.2f;
        if (Input.GetMouseButtonDown(0))
        {
            mouseLocForRay = new Vector2(mousePos.x, mousePos.y);
            HitOBject = Physics2D.Raycast(mouseLocForRay, Vector2.zero);
            if (HitOBject.collider.tag == "Monster Card" || HitOBject.collider.tag == "Spell Card")
            {
                monPrefab = HitOBject.collider.GetComponent<SummonInfo>().Prefab.gameObject;
                myCurrentObject = HitOBject.collider.GetComponent<SummonInfo>().Prefab.gameObject; 
                currCard = HitOBject.collider.gameObject;
                card = HitOBject.collider.gameObject;
                //myCurrentObject = Instantiate(monPrefab, mousePos, Quaternion.identity);
            }

            /*
            }
            if (Input.GetMouseButton(0) && myCurrentObject)
            {
               myCurrentObject.transform.position = mousePos;
            }
            if (Input.GetMouseButtonUp(0) && myCurrentObject)
            {
               myCurrentObject = null;
            }
            */
        }
    }
  public static void Discard()
    {
        myCurrentObject = null;
        Destroy(currCard);
        currCard = null;
    }
}