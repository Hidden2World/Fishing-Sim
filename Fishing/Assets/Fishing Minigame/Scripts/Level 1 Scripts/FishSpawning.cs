using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class FishSpawning : MonoBehaviour
{
    public GameObject[] Fish;

    private int randomFish;
    public float xValue;
    public float zValue;
    public Transform topSpawn11;
    public Transform bottomSpawn11;
    public Transform xSpawn;
    public int minFish;
    public int maxFish;
    // Start is called before the first frame update
    void Start()
    {
       
        int spawnAmmount = Random.Range(minFish, maxFish);
        int randomIndex = Random.Range(0, Fish.Length);
        for (int i = 0; i < spawnAmmount; i++)
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(topSpawn11.position.x, xSpawn.position.x), Random.Range(bottomSpawn11.position.y, topSpawn11.position.y), zValue);
            Instantiate(Fish[randomIndex], randomSpawnPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
