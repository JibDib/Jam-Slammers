using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkewerCollision : MonoBehaviour
{
    [SerializeField] private float collisionDst = 1;
    [SerializeField] private Transform originVector;
    private RaycastHit hit;

    private void Update()
    {
        Debug.DrawRay(originVector.position, transform.right * collisionDst, Color.green);
        
        if (Physics.Raycast(originVector.position, transform.right, out hit))
        {
            if (hit.transform.CompareTag("Player") && hit.distance < collisionDst)
            {
                print("raycast hit: " + hit.transform.name);
            }
        }
    }
}
