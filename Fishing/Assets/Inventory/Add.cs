using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Add : MonoBehaviour
{
    public TMP_Text cods;
    public TMP_Text  fish1;
    public TMP_Text Weight;
    public TMP_Text limitReached;

    private float codWeight = 10f;
    private float fishWeight = 5f;

    private float codAmount = 0f;
    private float fishAmount = 0f;
    

    private float totalWeight = 0f;
    public float maxWeight;
    private float warningWeight;
    private float weightLeft;


    public Transform buttonPanel;

    void Start()
    {
        warningWeight = maxWeight - 15;
    }

    private void Update()
    {
        weightLeft = maxWeight - totalWeight;
        if (totalWeight >= warningWeight)
        {
            limitReached.gameObject.SetActive(true);
            limitReached.text = $"You have {weightLeft}kg left!";
            if(totalWeight >= maxWeight)
            {
                limitReached.text = "Max Weight!";
                
            }
        }
    }

    public void Cod()
    {
        
        totalWeight += codWeight;
        if (totalWeight <= maxWeight)
        {
            limitReached.gameObject.SetActive(false);

            codAmount++;
            cods.text = $"{codAmount}x";
            Weight.text = $"Total Weight: {totalWeight}";
        }
        else
        {
            totalWeight -= codWeight;
            maxWeightReached();
        }
    }

    public void fishy()
    {
        
        totalWeight += fishWeight;
        if (totalWeight <= maxWeight)
        {
            limitReached.gameObject.SetActive(false);

            fishAmount++;
            fish1.text = $"{fishAmount}x";
            Weight.text = $"Total Weight: {totalWeight}";

        }
        else
        {
            totalWeight -= fishWeight;
            maxWeightReached();
        }
    }


    public void maxWeightReached()
    {
        limitReached.gameObject.SetActive(true);
    }

    


}