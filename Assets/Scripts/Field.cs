using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour {

    private void OnMouseUpAsButton()
    {
        if (ManaAdd.mana >= MonsterSpawner.myCurrentObject.GetComponent<SpawnCost>().spawnPrice)
        {
            if (MonsterSpawner.myCurrentObject != null && MonsterSpawner.myCurrentObject.tag == "Spell")
            {
                Instantiate(MonsterSpawner.myCurrentObject, transform.position, Quaternion.identity);

                //getComponent get's the script attached to the object which is set from mycurrentobject in monsterspawner.
                ManaAdd.mana -= MonsterSpawner.myCurrentObject.GetComponent<SpawnCost>().spawnPrice;
                MonsterSpawner.myCurrentObject = null;
            }
            else if (MonsterSpawner.myCurrentObject != null && MonsterSpawner.myCurrentObject.tag == "Wall")
            {
                Instantiate(MonsterSpawner.myCurrentObject, transform.position, Quaternion.identity);

                //getComponent get's the script attached to the object which is set from mycurrentobject in monsterspawner.
                ManaAdd.mana -= MonsterSpawner.myCurrentObject.GetComponent<SpawnCost>().spawnPrice;
                MonsterSpawner.myCurrentObject = null;
            }
        }
    }
}
