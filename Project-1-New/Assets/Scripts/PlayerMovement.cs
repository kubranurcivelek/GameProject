using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    using UnityEditor;
using UnityEditor.Experimental.GraphView;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float forwardForce ;
    public float sidewaysForce = 500f;
    public float maxSlopeAngle;
    private RaycastHit slopeHit;
    public float playerHeight;
    Vector3 moveDirection;
    public Transform orientation;
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
        MovePlayer();


    }

    private bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }
        return false;
    } 
    private Vector3 GetSlopeMoveDirection()
    {
        return Vector3.ProjectOnPlane(moveDirection, slopeHit.normal).normalized;
    }

    private void MovePlayer() 
    {
        if (OnSlope())
        {
            rigidbody.AddForce(GetSlopeMoveDirection());
        }
        rigidbody.useGravity = !OnSlope();
    }









}
