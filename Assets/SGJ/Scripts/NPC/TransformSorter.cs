using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformSorter : MonoBehaviour
{
    private const float scale = 0.01f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y * scale);
    }
}
