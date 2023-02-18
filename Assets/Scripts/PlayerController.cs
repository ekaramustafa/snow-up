using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool canMove = true;
    private Rigidbody2D rigidbody;
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostSpeed = 40f;
    [SerializeField] float baseSpeed = 20f;


    SurfaceEffector2D surfaceEffector2D;
    // Start is called before the first frame update
    void Start()
    {
         rigidbody = GetComponent<Rigidbody2D>();
         //accessing surface effector
         surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleRotation();
        Boost();
    }

    void Boost()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }

    }

    void HandleRotation()
    {
        if (canMove)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                //rotate to left
                rigidbody.AddTorque(torqueAmount);

            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                //rotate to right
                rigidbody.AddTorque(-torqueAmount);
            }

        }
    }
}
