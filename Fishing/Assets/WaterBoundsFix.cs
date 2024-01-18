using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBoundsFix : MonoBehaviour
{
  

        void Start()
        {
            // Recalculate bounds
            GetComponent<MeshFilter>().sharedMesh.RecalculateBounds();
        }

    // Update is called once per frame
    void Update()
    {
        
    }
}
