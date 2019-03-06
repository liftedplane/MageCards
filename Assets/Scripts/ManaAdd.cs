using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaAdd : MonoBehaviour {
    public int manaToAdd = 5;
    private int maxMana = 100;
    public static int mana = 90;
    public Text TotalMana;
    private int pUpMana;
    private Vector3 manaPos;
    private Vector2 findMana;
    private RaycastHit2D hitMana;

    private void Start()
    {
	   InvokeRepeating("addMana", 5, 5);
	   if (mana >= maxMana)
	   {
		  CancelInvoke("addMana");
	   }
	   TotalMana = GetComponent<Text>();
    }

    private void Update()
    {
	   if (Input.GetMouseButtonDown(0))
	   {
		  manaPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		  findMana = new Vector2(manaPos.x, manaPos.y);
		  hitMana = Physics2D.Raycast(findMana, Vector2.zero);
		  if (hitMana.collider.name == "Magic(Clone)")
		  {
			 addPowerUpMana();
		  }
		  else
		  {
			 Debug.Log("Try Again Stupid");
		  }
	   }
    }

    private void LateUpdate()
    {
	   TotalMana.text = "Mana: " + mana;
    }

    private void addMana()
    {
	   mana += manaToAdd;
    }

    private void addPowerUpMana()
    {
	   pUpMana = Random.Range(1, 8);
	   mana += pUpMana;
       Destroy(hitMana.collider.gameObject);
    }
}
