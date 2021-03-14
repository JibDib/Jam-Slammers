using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    [Header("Base Movement Vars")]
    [SerializeField] private int moveSpeed;
    [SerializeField] private int rotateSpeed;
    
    [Header("Dash Vars")]
    [SerializeField] private int dashMoveSpeed;
    [SerializeField] private int dashRotateSpeed;
    [SerializeField] private bool canDash = false;
    [SerializeField] private float dashTimer;
    [SerializeField] private float dashCooldown;
    [SerializeField] private bool isDashing = false;
    [SerializeField] private float dashDuration;
    private Vector2 inputVector;

    [Header("Player Objects")]
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
        Cooldowns();
        Movement();
    }

    //Apply the rotation on the player's skewer according the the input given
    private void ApplyRotations()
    {
        if (inputVector != Vector2.zero)
        {
            Vector3 lookDir = new Vector3(inputVector.x, 0, inputVector.y);
            skewerParent.transform.rotation = Quaternion.LookRotation(lookDir);
        }
    }
    
    //Keep track of cooldowns
    private void Cooldowns()
    {
        dashTimer += Time.deltaTime;

        if (dashTimer < dashCooldown)
        {
            canDash = false;
        }
        else
        {
            canDash = true;
            dashTimer = dashCooldown;
        }

        if (dashTimer >= dashDuration)
        {
            isDashing = false;
        }
    }
    
    //Apply rotation to the mount object and move the player in the direction the mount is facing
    private void Movement()
    {
        if (!isDashing)
        {
            mount.transform.rotation = Quaternion.Lerp(mount.transform.rotation, skewerParent.transform.rotation, rotateSpeed * Time.deltaTime);
            Vector3 moveDir = new Vector3(mount.transform.right.x, 0,mount.transform.right.z);
            rb.velocity = moveDir * moveSpeed;
        }
        else
        {
            mount.transform.rotation = Quaternion.Lerp(mount.transform.rotation, skewerParent.transform.rotation, dashRotateSpeed * Time.deltaTime);
            Vector3 moveDir = new Vector3(mount.transform.right.x, 0,mount.transform.right.z);
            rb.velocity = moveDir * dashMoveSpeed;
        }
    }
    
    //When called set isDashing to be true
    public void Dash()
    {
        if(canDash)
        {
            isDashing = true;
            dashTimer = 0f;
        }
    }
    
    //Set variables
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
