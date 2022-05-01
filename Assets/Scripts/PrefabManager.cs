using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PrefabManager more like Procedural Content generator to create an endless map
public class PrefabManager : MonoBehaviour
{
    /* Prefab List for comfortably ruled generation of path and obstacles
        * 0. Road
        * 1. Jump Over
        * 2. Slide Under
    */

    public GameObject[] prefabs;
    public float zSpawnPoint = 0;

    // Length in Z-axis for the whole prefab
    public float prefabLength = 20.0f;

    public int numberOfPrefabs = 5;

    public Transform playerTransform;

    private List<GameObject> activeGameObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < numberOfPrefabs; ++i)
        {
            // first tile needs to be the road to begin and then others
            if (i == 0)
                SpawnPrefab(0);
            else
                SpawnPrefab(Random.Range(0, prefabs.Length));
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Imaginary checkpoint after the character has passed a good amount of length
        if (playerTransform.position.z > zSpawnPoint - (numberOfPrefabs * prefabLength))
        {
            SpawnPrefab(Random.Range(0, prefabs.Length));

            // Garbage Collection
            DeletePrefab();
        }
    }

    public void SpawnPrefab(int prefabIndex)
    {
        // Rules as follows: 
        // Each obstacle and prefab with rules as to be placed in the world
        switch(prefabIndex)
        {
            case 0: // Road Obstacle, place as is, no changes
                {
                    GameObject go = Instantiate(prefabs[prefabIndex], transform.forward * zSpawnPoint, transform.rotation);
                    zSpawnPoint += prefabLength;

                    // Add to the list of active gameObjects
                    activeGameObjects.Add(go);
                }
                break;

            case 1: // Jump Over obstacle needs to be placed on the ground with limited height for character to jump over
                {
                    GameObject go = Instantiate(prefabs[prefabIndex], transform.forward * zSpawnPoint, transform.rotation * Quaternion.Euler(90.0f, -90.0f, 90.0f));
                    zSpawnPoint += prefabLength;

                    // Add to the list of active gameObjects
                    activeGameObjects.Add(go);
                }
                break;

            case 2: // Slide Under Obstacle needs to be a little above the ground for the character to comfortably slide under 
                {
                    GameObject go = Instantiate(prefabs[prefabIndex], new Vector3(0f, 3.0f, 0f) /** transform.forward * zSpawnPoint*/, transform.rotation * Quaternion.Euler(90.0f, -90.0f, 90.0f));
                    zSpawnPoint += prefabLength;

                    // Add to the list of active gameObjects
                    activeGameObjects.Add(go);
                }
                break;

            default: // Code should not reach here, if so, debug heavily
                {
                    Debug.Log("Ghost code, Unreachable point");
                }
                break;
        };
    }

    public void DeletePrefab()
    {
        Destroy(activeGameObjects[0]);
        activeGameObjects.RemoveAt(0);
    }
}
