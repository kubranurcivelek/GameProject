using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchScreen : MonoBehaviour
{

    Rigidbody rigi;

    bool left;
    bool right;
    float speed = 5.0f;
    /*
    float jump = 500.0f;

    public float jumpPower;
    Vector2 startPoint, endPoint;
    bool canJump;
    */



    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);

        Vector3 go_right = new Vector3(5.50f, transform.position.y, transform.position.z);
        Vector3 go_left = new Vector3(-5.50f, transform.position.y, transform.position.z);

        if (Input.touchCount > 0)
        {
            Touch finger = Input.GetTouch(0);

            if (finger.deltaPosition.x > 5.0f)
            {
                right = true;
                left = false;
            }
            if (finger.deltaPosition.x < -5.0f)
            {
                right = false;
                left = true;
            }
            /*
            if (finger.deltaPosition.y > 5.0f)
            {
                rigi.velocity = Vector3.zero;
                rigi.velocity = Vector3.up * jump;
            }
            
            if(endPoint.y > startPoint.y && rigi.velocity.y == 0)
            {
                canJump = true;
                endPoint = Vector2.zero;
                startPoint = Vector2.zero;
            }
            */

            if (right == true)
            {
                transform.position = Vector3.Lerp(transform.position, go_right, 5 * Time.deltaTime);
            }
            if (left == true)
            {
                transform.position = Vector3.Lerp(transform.position, go_left, 5 * Time.deltaTime);
            }
        }
    }

    /*
    private void FixedUpdate()
    {
        if (canJump)
        {
            rigi.AddForce(Vector3.up * jumpPower);
            canJump = false;
        }
    }
    */
}