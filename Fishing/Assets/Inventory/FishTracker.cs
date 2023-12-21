using UnityEngine;
using UnityEngine.UI;

// making a type for each fish
public enum fishtype { clownfish, seabass, shark, seahorse, squid };

/// <summary>
/// this class is here to store all the information for the fish used
/// </summary>
public class FishTracker : MonoBehaviour
{
    // the weight of each fish
    public float weight;
    // the price of each fish
    public float price;
    // the description of each fish
    public string FishDescription;
    // the type of each fish
    public fishtype type;
    // the image for each fish
    public Sprite FishImage;

    public FishTracker fishPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
