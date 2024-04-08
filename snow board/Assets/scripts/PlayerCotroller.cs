using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCotroller : MonoBehaviour
{
    [SerializeField] float TorqueAmount = 1f;
    // [SerializeField] float boostSpeed = 30f;
    // [SerializeField] float baseSpeed = 20f;

    bool canMove = true;
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            ResponseToBoost();
        }
        else
        {
            surfaceEffector2D.forceScale = 0f;
        }

    }

    void ResponseToBoost()
    {
        //if push, then speed up
        //otherwise, stay in base speed
        //acess surface effector & controll speed->force

        if (Input.GetKey(KeyCode.Space))
        {
            surfaceEffector2D.forceScale = 0.01f;
        }
        else
        {
            surfaceEffector2D.forceScale = 0.001f;
        }
    }

    public void DisableControls()
    {
        canMove = false;
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(TorqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-TorqueAmount);
        }
    }
}
