using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour, ISpawns
{
    public ItemPickUps_SO[] itemDefinitions;

    private int whichToSpawn = 0;
    private int totalSpawnWeight = 0;
    private int chosen = 0;

    public Rigidbody itemSpawned { get; set; }
    public Renderer itemMaterial { get; set; }
    public ItemPickUp itemType { get; set; }


    void Start()
    {
        foreach (ItemPickUps_SO item in itemDefinitions)
        {
            totalSpawnWeight += item.spawnChanceWeight;
        }
    }

    public void CreateSpawn()
    {
        foreach (ItemPickUps_SO item in itemDefinitions)
        {
            whichToSpawn += item.spawnChanceWeight;
            if (whichToSpawn >= chosen)
            {
                itemSpawned = Instantiate(item.itemSpawnObject, transform.position, Quaternion.identity);

                itemMaterial = itemSpawned.GetComponent<Renderer>();
                itemMaterial.material = item.itemMaterial;

                itemType = itemSpawned.GetComponent<ItemPickUp>();
                itemType.itemDefinition = item;
                break;
            }
        }
    }

}
