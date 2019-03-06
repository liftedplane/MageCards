using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangedMoveAndAttack : MonoBehaviour {

    private Vector2 movementSpeed;
    public Vector2 defSpeed;
    private Vector2 stopped = Vector2.zero;
    public float attackStr;
    public float attackSpeed = 0.5f;
    private float nextAttack = 0.0f;
    public float range;

    private bool isColliding;
    private RaycastHit2D Hit;
    public LayerMask filter;

    public GameObject projectile;
    private GameObject firing;

    public GameObject aim;
    private Vector3 AimPos;
    // Use this for initialization
    void Start()
    {
        range = 3f;
        movementSpeed = defSpeed;
    }

    private void FixedUpdate()
    {
        AimPos = aim.transform.position - transform.position;
        Hit = Physics2D.Raycast(transform.position, AimPos, range, filter);

        if (Hit.collider == true)
        {
            movementSpeed = stopped;
            if (Time.time > nextAttack)
            {
                nextAttack = Time.time + attackSpeed;
                Debug.Log("Time Set attack");
                launchProjectile();
            }
        }

        Debug.DrawRay(transform.position, AimPos);
        GetComponent<Rigidbody2D>().velocity = movementSpeed;
        if (isColliding == false)
        {
            movementSpeed = defSpeed;
        }

    }
    private void launchProjectile()
    {
        firing = Instantiate(projectile, transform.position, transform.rotation,transform);
        firing.GetComponent<Rigidbody2D>().velocity = AimPos;
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
            movementSpeed = Vector2.zero;
            if (Time.time > nextAttack)
            {
                nextAttack = Time.time + attackSpeed;
                trigCol.gameObject.GetComponent<Health>().doDamage(attackStr);
            }
        }
        //if (trigCol.gameObject.GetComponent<Health>().curHP <= 0)
        //{
        //    Debug.Log("Player is dead");
        //    isColliding = false;
        //}
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isColliding = false;
    }
}
