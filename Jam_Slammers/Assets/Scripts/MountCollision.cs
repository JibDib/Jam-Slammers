using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountCollision : MonoBehaviour
{

    [SerializeField] private Transform skewerParent;
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Vector3 reflectDir = Vector3.Reflect(transform.forward, other.GetContact(0).normal);
            transform.rotation = Quaternion.FromToRotation(Vector3.forward, reflectDir);
            skewerParent.rotation = Quaternion.FromToRotation(Vector3.forward, reflectDir);
        }
    }
}
