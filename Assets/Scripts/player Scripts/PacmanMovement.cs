using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PacmanMovement : MonoBehaviour
{
    [SerializeField] Rigidbody PacmanRb;
    [SerializeField] float Speed;

    [SerializeField] float rayDistance;

    //camera empty
    public Transform emptyForCam;

    //*//
    public Vector3 forward;
    public Vector3 backward;
    public Vector3 right;
    public Vector3 left;
    //*// 

    [SerializeField] bool rayHitFront;
    [SerializeField] bool rayHitBack;
    [SerializeField] bool rayHitRight;
    [SerializeField] bool rayHitLeft;

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

        DrawVectorRay();//draws rays to each direction to visualize the ray distance
        Movement();
        emptyForCam.transform.position = this.transform.position;//makes the empty the camera looks at only move with pacman and not rotate.
    }

    private void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(forward), out hit, rayDistance, CheckWallLayer))
        {
            rayHitLeft = true;
        }
        else
        {
            rayHitLeft = false;
        }

        /*---------------------------------------------*/

        if (Physics.Raycast(transform.position, transform.TransformDirection(backward), out hit, rayDistance, CheckWallLayer))
        {
            rayHitRight = true;
        }
        else
        {
            rayHitRight = false;
        }



        if (Physics.Raycast(transform.position, transform.TransformDirection(right), out hit, rayDistance, CheckWallLayer))
        {
            rayHitFront = true;
        }
        else
        {
            rayHitFront = false;
        }



        if (Physics.Raycast(transform.position, transform.TransformDirection(left), out hit, rayDistance, CheckWallLayer))
        {
            rayHitBack = true;
        }
        else
        {
            rayHitBack = false;
        }
     
    }

    public void Movement()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime, Space.Self);
        
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
