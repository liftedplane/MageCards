using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour {


    private void OnMouseUpAsButton()
    {
        if (MonsterSpawner.myCurrentObject != null
             && ManaAdd.mana >= MonsterSpawner.myCurrentObject.GetComponent<SpawnCost>().spawnPrice)
        {
            Instantiate(MonsterSpawner.myCurrentObject, transform.position, Quaternion.identity);

            //getComponent get's the script attached to the object which is set from mycurrentobject in monsterspawner.
            ManaAdd.mana -= MonsterSpawner.myCurrentObject.GetComponent<SpawnCost>().spawnPrice;
            MonsterSpawner.myCurrentObject = null;

        }
    }
}
