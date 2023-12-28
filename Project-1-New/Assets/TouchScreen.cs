using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchScreen : MonoBehaviour
{

    public Rigidbody rb;


    public float forwardForce = 5000f;
    public float sidewaysForce = 500f;

    [Space]
    public float moveX;

    private Touch touch;




    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {

            touch = Input.GetTouch(0);


            if (touch.phase == TouchPhase.Moved)
            {

                moveX = touch.deltaPosition.x;
            }
            else
            {

                moveX = 0f;
            }
        }
    }

    void FixedUpdate()
    {
        //Add a forward force.
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        //Add a right force
        rb.AddForce(sidewaysForce * moveX * Time.deltaTime, 0, 0, ForceMode.Force);

        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }






}


