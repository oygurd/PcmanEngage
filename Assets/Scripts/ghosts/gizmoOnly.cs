using UnityEngine;

public class gizmoOnly : MonoBehaviour
{
    [SerializeField] bool drawSquare = true;
    [SerializeField] bool drawCircle = true;
    [SerializeField] Vector3 squareSize = new Vector3(0,0,0);
    [SerializeField] float circleSize = 1f;

    void OnDrawGizmos()
    {
        if (drawSquare)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawCube(transform.position, squareSize);
        }

        if (drawCircle)
        {
            Gizmos.color = Color.gray;
            Gizmos.DrawSphere(transform.position, circleSize);
        }
    }
}