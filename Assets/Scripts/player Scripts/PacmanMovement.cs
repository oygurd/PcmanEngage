using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMovement : MonoBehaviour
{
    [SerializeField] Rigidbody PacmanRb;
    [SerializeField] float Speed;

    [SerializeField] float rayDistance;


    //*//
    public Vector3 forward;
    public Vector3 backward;
    public Vector3 right;
    public Vector3 left;
    //*// 

    [SerializeField] bool rayHit;
    [SerializeField] LayerMask CheckWallLayer;
    RaycastHit hit; //get information back from a raycast

    // Start is called before the first frame update
    void Start()
    {
        rayDistance = 2.1f;
        PacmanRb = GetComponent<Rigidbody>();

        //*//       
        forward = transform.TransformDirection(Vector3.forward);
        backward = transform.TransformDirection(Vector3.back);
        right = transform.TransformDirection(Vector3.right);
        left = transform.TransformDirection(Vector3.left);
        //*//
    }

    // Update is called once per frame
    void Update()
    {

        DrawVectorRay();
    }

    private void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, rayDistance, CheckWallLayer))
        {
            rayHit = true;
        }
        else
        {
            rayHit = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(transform.position, Vector3.forward);
    }

    public void DrawVectorRay()//using debug command to see the distance of all rays to have a visual confirmation
    {
        Debug.DrawRay(transform.position, forward * rayDistance, Color.blue);

        Debug.DrawRay(transform.position, backward * rayDistance, Color.cyan);

        Debug.DrawRay(transform.position, right * rayDistance, Color.red);

        Debug.DrawRay(transform.position, left * rayDistance, Color.cyan);


    }
}
