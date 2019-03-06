using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSpawn : MonoBehaviour {
    //public variable for theprefab
    public GameObject magicPrefab;

    private void Start()
    {
	   //Random range min inclusive, max exclusive.
	   InvokeRepeating("spawnMagic", (Random.Range(6, 11)), (Random.Range(10, 35)));
    }

    void spawnMagic()
    {
	   //load prefab transform.position to find current position quaternion.identity def rotation
	   Instantiate(magicPrefab, transform.position + transform.right * (Random.Range(1,9)), Quaternion.identity);
    }
}
