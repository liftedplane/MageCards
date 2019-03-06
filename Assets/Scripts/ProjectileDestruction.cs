using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDestruction : MonoBehaviour {

    private void Start()
    {
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.parent.gameObject.tag == "Monster")
        {
            if (collision.gameObject.tag == "EnemyMob" || collision.gameObject.tag == "Tower")
            {
                collision.gameObject.GetComponent<Health>().doDamage(5f);
                Destroy(gameObject);
            }
        }
        else if (transform.parent.gameObject.tag == "EnemyMob")
        {
            if (collision.gameObject.tag == "Monster" || collision.gameObject.tag == "Player Tower" || collision.gameObject.tag == "Wall")
            {
                collision.gameObject.GetComponent<Health>().doDamage(5f);
                Destroy(gameObject);
            }
        }
    }
}
