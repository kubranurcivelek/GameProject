using UnityEditor;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private Vector3 end;

    private Vector3 startPosition;
    private Vector3 endPosition;

    private float pingPong;

    private void Start()
    {
        startPosition = transform.position;
        endPosition = transform.TransformPoint(end);
    }

    private void Update()
    {
        pingPong = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(startPosition, endPosition, pingPong);
    }

#if UNITY_EDITOR

    private void OnDrawGizmosSelected()
    {
        if (!Application.isPlaying)
            endPosition = transform.TransformPoint(end);

        Gizmos.color = Color.green;
        Gizmos.DrawSphere(endPosition, 0.15f);

        Handles.color = Color.green;
        Handles.DrawLine(transform.position, endPosition);
    }
#endif

}
