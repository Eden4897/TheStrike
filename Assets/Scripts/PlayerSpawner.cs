using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{

    public GameObject p1Prefab;
    public GameObject DestroyOnSpawn;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            GameObject a = Instantiate(p1Prefab, transform.position, transform.rotation) as GameObject;
            Destroy(DestroyOnSpawn);
        }
    }
}
