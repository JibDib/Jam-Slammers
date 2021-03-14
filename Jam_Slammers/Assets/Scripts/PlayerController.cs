using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private int speed;
    [SerializeField] private int rotateSpeed;
    private Vector2 inputVector;

    [SerializeField] private GameObject skewerParent;
    [SerializeField] private GameObject skewer;
    [SerializeField] private GameObject rider;
    [SerializeField] private GameObject mount;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        ApplyRotations();
        Movement();
    }

    private void ApplyRotations()
    {
        if (inputVector != Vector2.zero)
        {
            Vector3 lookDir = new Vector3(inputVector.x, 0, inputVector.y);
            skewerParent.transform.rotation = Quaternion.LookRotation(lookDir);
        }
    }
    
    private void Movement()
    {
        mount.transform.rotation = Quaternion.Lerp(mount.transform.rotation, skewerParent.transform.rotation, rotateSpeed * Time.deltaTime);
        rb.MovePosition(transform.position + mount.transform.right * (speed * Time.deltaTime));
    }

    public void SetInputVector(Vector2 inputVector)
    {
        this.inputVector = inputVector;
    }

    public void SetSkewer(GameObject skewer)
    {
        this.skewer = skewer;
    }

    public void SetMount(GameObject mount)
    {
        this.mount = mount;
    }

    public void SetRider(GameObject rider)
    {
        this.rider = rider;
    }
}
