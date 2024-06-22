using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] float torqueAmount = 3f;
    [SerializeField] float boostSpeed = 50f;

    [SerializeField] float normalSpeed = 20f;

    SurfaceEffector2D surfaceEffector2D;
    bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove) {
            NewRotatePlayer();
            RespondToBoost();
        }
        else
            disableControls();
    }


    public void disableControls(){
        canMove = false;
    }

    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            surfaceEffector2D.speed = boostSpeed;
        else
            surfaceEffector2D.speed = normalSpeed;
    }

    public void NewRotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            rb2d.AddTorque(torqueAmount);
        else if (Input.GetKey(KeyCode.RightArrow))
            rb2d.AddTorque(-torqueAmount);
    }
}
