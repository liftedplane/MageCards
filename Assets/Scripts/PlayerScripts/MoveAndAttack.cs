using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndAttack : MonoBehaviour {
    private Vector2 movementSpeed;
    public Vector2 defSpeed;
    private Vector2 stopped = Vector2.zero;
    public float attackStr;
    public float attackSpeed = 0.5f;
    private float nextAttack = 0.0f;
    private bool isColliding;

	// Use this for initialization
	void Start ()
    {
	   movementSpeed = defSpeed;
    }

    private void FixedUpdate()
    {
	   GetComponent<Rigidbody2D>().velocity = movementSpeed;
	   if (isColliding == false)
	   {
		  movementSpeed = defSpeed;
	   }
    }

    private void OnTriggerStay2D(Collider2D trigCol)
    {
       if (trigCol.gameObject.tag == "Tower")
	   {
		  isColliding = true;
		  movementSpeed = stopped;
		  if (Time.time > nextAttack)
		  {
			 nextAttack = Time.time + attackSpeed;
			 Debug.Log("Time Set attack");
			 trigCol.gameObject.GetComponent<Health>().doDamage(attackStr);
		  }
	   }
	   if (trigCol.gameObject.tag == "EnemyMob")
	   {
		  isColliding = true;
		  movementSpeed = Vector2.zero;
		  if (Time.time > nextAttack)
		  {
			 nextAttack = Time.time + attackSpeed;
			 trigCol.gameObject.GetComponent<Health>().doDamage(attackStr);
		  }
	   }

	   //if (trigCol.gameObject.GetComponent<Health>().curHP <= 0)
	   //{
		  //Debug.Log("enemy is dead");
		  //isColliding = false;
	   //}
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isColliding = false;
    }
}
