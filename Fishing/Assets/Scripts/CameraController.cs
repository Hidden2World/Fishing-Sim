using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float distance;


    void Start()
    {
        
    }


    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y + distance, target.transform.position.z - distance);
    }
}
