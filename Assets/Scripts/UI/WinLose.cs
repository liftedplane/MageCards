using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLose : MonoBehaviour
{
    public List<GameObject> EnemyTowersList = new List<GameObject>();
    public List<GameObject> PlayerTowersList = new List<GameObject>();
    [SerializeField]
    private string GameOverLevel;

    private void Awake()
    {
        //Creates a list of enemy towers then a list of player towers to check if they are still there.
        EnemyTowersList.AddRange(GameObject.FindGameObjectsWithTag("Tower"));

        PlayerTowersList.AddRange(GameObject.FindGameObjectsWithTag("Player Tower"));

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerTowersList.Count <= 0 || EnemyTowersList.Count <= 0)
        {
            SceneManager.LoadScene(GameOverLevel);
        }
    }

}
