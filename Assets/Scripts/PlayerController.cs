using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool canMove = true;
    private Rigidbody2D rigidbody;
    [SerializeField] private float torqueAmount = 1f;
    // Start is called before the first frame update
    void Start()
    {
         rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        handleRotation();
    }

    void handleRotation()
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
