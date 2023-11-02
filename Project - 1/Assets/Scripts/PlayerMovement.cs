using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float forwardForce ;
    public float sidewaysForce = 500f;
   
    public void FixedUpdate()
    {
        rigidbody.AddForce(0, 0, forwardForce * Time.deltaTime);

        bool moveRight = Input.GetKey("d");
        bool moveLeft = Input.GetKey("a");
        bool space = Input.GetKey(KeyCode.Space);

        if (moveRight)
        {
            rigidbody.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (moveLeft)
        {
            rigidbody.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (space)
        {
            rigidbody.AddForce(0, sidewaysForce * Time.deltaTime, 0, ForceMode.VelocityChange);
        }


        if(rigidbody.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();

        }



    }








}
