﻿using System.Collections;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Component References.
    Player playerM;
    Rigidbody rb;
    SpriteRenderer renderer;
    Vector3 movement;
    [SerializeField] float groundRotation;

    float horizontal, vertical;

    [SerializeField] float speed;
    [SerializeField] float dashSpeed;
    [SerializeField] float dashLength;
    float dashStart;
    bool isDashing;

    void Start()
    { 
        playerM = GetComponent<Player>();
        rb = GetComponent<Rigidbody>();
        renderer = GetComponent<SpriteRenderer>();
        isDashing = false;
    }

    // Update is called once per frame
    void Update()
    {
        setMovementVector();
        move();
    }

    private void setMovementVector()
    {
        playerM.getMovementAxes(ref horizontal, ref vertical);
        movement = new Vector3(horizontal, vertical, 0);
        Quaternion rotation = Quaternion.Euler(groundRotation, 0, 0);
        movement = rotation * movement;
    }

    void move()
    {
         if (Input.GetKeyDown(KeyCode.C))
        {
            isDashing = true;
            Debug.Log("Dashing!");
            teleDash();
        }

        else
        {
            isDashing = false;
            rb.MovePosition(transform.position + movement * speed *  Time.deltaTime);
        }
    }

    public bool isMoving()
    {
        return movement.magnitude != 0;
    }

    public bool isDash()
    {
        return isDashing;
    }

    void teleDash()
    {
        StartCoroutine(dash());
        //rb.MovePosition(transform.position + movement * dashLength * Time.deltaTime);

    }

    IEnumerator dash()
    {
        for (int i=0; i<5; i++)
        { 
            rb.MovePosition(transform.position + movement * dashSpeed * Time.deltaTime);
            yield return null;

        }

    }
}



//TODO:change the sorting layer dynamically according to player position.