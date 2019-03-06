﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveAndAttack : MonoBehaviour
{
    private Vector2 movementSpeed;
    public Vector2 defSpeed;
    private Vector2 stopped =  Vector2.zero;
    public float attackStr;
    public float attackSpeed = 0.5f;
    private float nextAttack = 0.0f;
    public bool isColliding;

    // Use this for initialization
    void Start()
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
       
       //trigCol = gameObject.GetComponent(typeof(BoxCollider2D)) as Collider2D;
	   if (trigCol.gameObject.tag == "Player Tower" || trigCol.gameObject.tag == "Wall")
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

	   if (trigCol.gameObject.tag == "Monster")
	   {
		  isColliding = true;
		  movementSpeed = stopped;
		  if (Time.time > nextAttack)
		  {
			 nextAttack = Time.time + attackSpeed;
			 trigCol.gameObject.GetComponent<Health>().doDamage(attackStr);
		  }
	   }
	   //if (trigCol.gameObject.GetComponent<Health>().curHP <= 0)
	   //{
		  //Debug.Log("player is dead");
		  //isColliding = false;
	   //}
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isColliding = false;
    }
}
