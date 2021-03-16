using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //TODO Clamp skewer rotation to be a custom variable
    private Rigidbody rb;
    private Transform camTransform;
    private Vector2 inputVector;

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

    [Header("Player Objects")]
    [SerializeField] private GameObject skewerParent;
    [SerializeField] private GameObject skewer;
    [SerializeField] private GameObject rider;
    [SerializeField] private GameObject mount;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        camTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    private void FixedUpdate()
    {
        ApplyRotations();
        Cooldowns();
        Movement();
    }

    private float initAngle = -1;

    private int clampAngle = 60;
    //Apply the rotation on the player's skewer according the the input given
    private void ApplyRotations()
    {
        if (inputVector != Vector2.zero)
        {
            Vector3 lookDir = inputVector.x * camTransform.right + inputVector.y * camTransform.forward;
            lookDir.y = 0;
            
            
            if (initAngle == -1)
            {
                initAngle = Vector3.Angle(lookDir, mount.transform.forward);
            }

            var angle = Vector3.Angle(lookDir, mount.transform.forward);
            
            print($"{angle - initAngle}");
            
            if (angle > initAngle + clampAngle)
            {
                return;
            }

            if (angle < -(initAngle - clampAngle))
            {
                return;
            }
            
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
            Vector3 moveDir = new Vector3(mount.transform.forward.x, 0,mount.transform.forward.z);
            rb.velocity = moveDir * moveSpeed;
        }
        else
        {
            mount.transform.rotation = Quaternion.Lerp(mount.transform.rotation, skewerParent.transform.rotation, dashRotateSpeed * Time.deltaTime);
            Vector3 moveDir = new Vector3(mount.transform.forward.x, 0,mount.transform.forward.z);
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
