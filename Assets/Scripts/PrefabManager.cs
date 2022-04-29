using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PrefabManager more like Procedural Content generator to create an endless map
public class PrefabManager : MonoBehaviour
{
    /* Prefab List for comfortably ruled generation
        * 0. Road
        * 1. WallRight
        * 2. WallLeft
    */

    public GameObject[] prefabs;
    public float zSpawnPoint = 0;

    // Length in Z-axis for the whole prefab
    public float prefabLength = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPrefab(0);
        SpawnPrefab(1);
        SpawnPrefab(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPrefab(int prefabIndex)
    {
        Instantiate(prefabs[prefabIndex], transform.forward * zSpawnPoint, transform.rotation);

        zSpawnPoint += prefabLength;
    }
}
