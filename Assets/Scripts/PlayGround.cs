using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGround : MonoBehaviour {

    private void OnCollisionExit2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
