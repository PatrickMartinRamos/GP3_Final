using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public List<GameObject> Bosses;

    [SerializeField]
    private GameObject BossPrefab; //Change Type after Creating Boss Script
    private void Awake()
    {
        foreach(var boss in Bosses)
        {
            Instantiate(boss,this.transform.position,this.transform.rotation, transform);
            boss.SetActive(false);
        }
    }
    public GameObject SpawnRandomBoss()
    {

        if (BossPrefab != null)
        {
            BossPrefab.SetActive(true);
            Debug.Log("Random Child Selected: " + BossPrefab.name);
            return BossPrefab;
        }
        else
        {
            Debug.LogError("No children found.");
            return null;
        }

    }
    public GameObject GetBossToSpawn()
    {
        GameObject temp;
        do
        {
            temp = GetRandomChild(this.transform);
        }
        while (BossPrefab == temp);

        BossPrefab = temp;

        return BossPrefab;
    }

    GameObject GetRandomChild(Transform parent)
    {
        int childCount = parent.childCount;

        if (childCount > 0)
        {
            // Get a random index within the range of the number of children
            int randomChildIndex = Random.Range(0, childCount);

            // Get the child GameObject at the random index
            GameObject randomChild = parent.GetChild(randomChildIndex).gameObject;

            return randomChild;
        }

        return null;
    }

    public GameObject InitializeBoss()
    {
        return BossPrefab = GetRandomChild(this.transform);
    }
}
