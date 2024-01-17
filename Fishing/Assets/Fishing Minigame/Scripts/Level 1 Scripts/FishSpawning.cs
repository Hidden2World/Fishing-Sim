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

    public float weightMax;
    public float weightMin;

    private GameObject fishClone;
    // Start is called before the first frame update
    void Start()
    {
       
        int spawnAmmount = Random.Range(minFish, maxFish);
        for (int i = 0; i < spawnAmmount; i++)
        {
            int randomLength = Random.Range(0, Fish.Length);
            //float randomWeight = Random.Range(weightMin, weightMax);
            Vector3 randomSpawnPosition = new Vector3(Random.Range(topSpawn11.position.x, xSpawn.position.x), Random.Range(bottomSpawn11.position.y, topSpawn11.position.y), zValue);
            fishClone = Instantiate(Fish[randomLength], randomSpawnPosition, Quaternion.identity);
            //fishClone.GetComponent<FishTracker>().weight = randomWeight;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
