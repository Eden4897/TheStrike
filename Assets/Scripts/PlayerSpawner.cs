using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject DestroyOnSpawn;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            GameObject a = Instantiate(playerPrefab, transform.position, transform.rotation) as GameObject;
            Destroy(DestroyOnSpawn);
        }
    }
}
