using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blast : MonoBehaviour {
    private float Radius;
    public int damage;
    private RaycastHit2D[] Hit;
    private Vector2 Origin;
    private Vector2 Direction;
    public LayerMask Filter;
	// Use this for initialization
	void Start () {
        Radius = 1f;
        Origin = gameObject.transform.position;
        Direction = Vector2.zero;
        Destroy(gameObject,.5f);
	}
	
	// Update is called once per frame
	void Update () {
        Hit = Physics2D.CircleCastAll(Origin, Radius, Direction, 3f,Filter);
        foreach(RaycastHit2D hit in Hit)
        {
            hit.collider.gameObject.GetComponent<Health>().doDamage(damage);
        }
        
	}
}
