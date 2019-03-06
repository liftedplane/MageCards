using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPowerUp : MonoBehaviour {

    private Vector2 floatSpeed;


    private void Start()
    {
	   floatSpeed.y = (Random.Range(0.05f, 0.4f));
    }

    private void LateUpdate()
    {
	   GetComponent<Rigidbody2D>().velocity = floatSpeed;
	   Destroy(gameObject, 9.0f);
    }
}
