using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField]
    private GameObject EventHandler;
    public float curHP = 10f;
    public float curARM = 10f;
    public float fullHP;

    private void Awake()
    {
        EventHandler = GameObject.FindGameObjectWithTag("Event Handlers");
    }

    private void Start()
    {
        fullHP = curHP;
    }
    public void doDamage(float n)
    {
        curARM -= n;
        if (curARM <= 0)
        {
            //subtract health
            curARM = 0;
            curHP -= n;
        }

	   //kill player if at 0
	   if (curHP <= 0)
        {
            //is this an enemy tower?
            if(this.gameObject.tag == "Tower")
            { EventHandler.GetComponent<WinLose>().EnemyTowersList.Remove(this.gameObject); }
            //or is this a player tower?
            else if(this.gameObject.tag == "Player Tower")
            { EventHandler.GetComponent<WinLose>().PlayerTowersList.Remove(this.gameObject); }
            
            Destroy(gameObject);
        }
		  
    }
    public float getHeath()
    { return curHP / fullHP; }

}
