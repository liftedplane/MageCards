using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
    //public variable for theprefab
    public GameObject monsterPrefab;
    public GameObject otherMon;
    private int swap;

    private void Start()
    {
	   //Random range min inclusive, max exclusive.
	   InvokeRepeating("spawnMonster", (Random.Range(2, 5)), (Random.Range(7, 14)));
    }

    void spawnMonster()
    {
        swap = Random.Range(1, 20);
        //load prefab transform.position to find current position quaternion.identity def rotations
        if (swap <= 10)
        { Instantiate(monsterPrefab, transform.position + -transform.right, Quaternion.identity); }
        else if (swap > 10)
        { Instantiate(otherMon, transform.position + -transform.right, Quaternion.identity); }
	  
    }
}
