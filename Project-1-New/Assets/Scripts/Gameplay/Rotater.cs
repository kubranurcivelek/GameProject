using UnityEngine;

public class Rotater : MonoBehaviour
{
    public enum Direction
    {
        Forward, Right, Up
    }

    [SerializeField] private Direction direction;
    [SerializeField] private float speed;
    [SerializeField] private bool isNegative;

    private Vector3 rotateDirection;

    private void Start()
    {
        SetDirection(direction);
    }

    private void Update()
    {
        transform.Rotate(rotateDirection, speed * Time.deltaTime);
    }

    private void SetDirection(Direction direction)
    {
        switch (direction)
        {
            case Direction.Forward:
                rotateDirection = Vector3.forward;
                break;

            case Direction.Right:
                rotateDirection = Vector3.right;
                break;

            case Direction.Up:
                rotateDirection = Vector3.up;
                break;
        }

        rotateDirection = isNegative ? -rotateDirection : rotateDirection;
    }
}
