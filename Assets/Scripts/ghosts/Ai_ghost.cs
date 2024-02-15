using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ai_ghost : MonoBehaviour
{

    [SerializeField] NavMeshAgent agent;

    [SerializeField] Transform player;

    [SerializeField] LayerMask whatIsGraound, whatIsPlayer;

    [SerializeField] float directionDistens;

    //cerent plane
    [SerializeField] Vector3 walkPoint;
    private bool walkPointSet;
    float howClose = 0;
    [SerializeField] Vector3 CurrentDirection;

    //powering up
    [SerializeField] float timeBetweenPowerUps;
    private bool alreadyPowerdUp;

    //states
    [SerializeField] float sightRange, powerUpRange, chaseActive;
    [SerializeField] bool playerInSightRange, playerInPowerUpRange;

    //triger Run Frome Player
    [SerializeField] bool powerUp;

    //dead
    [SerializeField] bool isDead;
    [SerializeField] Transform start;

    private void Awake()
    {
        player = GameObject.Find("player").transform;
        agent = GetComponent<NavMeshAgent>();
        walkPoint = transform.position;
    }

    [SerializeField] float speed;
    private void Update()
    {
        if (isAlmostZero (transform.position.x - walkPoint.x) && isAlmostZero(transform.position.z - walkPoint.z))
        {
            //Check for sight and attack range
            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
            playerInPowerUpRange = Physics.CheckSphere(transform.position, powerUpRange, whatIsPlayer);

            //if (pawerUp) RunFromePlayer();
            //if (isDead) thed2();
            if (!CheckDirection(CurrentDirection))
            {
                ClosestToPlayer();
                Debug.Log(CurrentDirection);
            }
            Debug.Log((CurrentDirection * Time.deltaTime * speed).normalized);
            transform.Translate(CurrentDirection * Time.deltaTime * speed);



            //if (CheckDirecshen(new Vector2(1, 0))) return;
            //if (CheckDirecshen(new Vector2(-1, 0))) return;
            //if (CheckDirecshen(new Vector2(0, 1))) return;
            //if (CheckDirecshen(new Vector2(0, -1))) return;

            //if (!playerInSightRange && !playerInPowerUpRange) Patroling();
            //if (playerInSightRange && !playerInPowerUpRange) ChasePlayer();
            //if (playerInSightRange && playerInPowerUpRange) AttackPlayer();
            
        }
        
    }
    private bool CheckDirection(Vector3 direcshen)
    {
        walkPoint = new Vector3(transform.position.x + direcshen.x, transform.position.y, transform.position.z + direcshen.z);
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGraound))
        {
            return true;
        }
        return false;
    }
    private void CheckDirecshenAndClosest(Vector3 direcshen)
    {
        Vector3 tempWalkPoint;
        tempWalkPoint = new Vector3(transform.position.x + direcshen.x, transform.position.y, transform.position.z + direcshen.z);
        if (Physics.Raycast(tempWalkPoint, -transform.up, 2f, whatIsGraound))
        {
            if (howClose < Vector3.Distance(tempWalkPoint, player.position))
            {
                howClose = Vector3.Distance(tempWalkPoint, player.position);
                walkPoint = tempWalkPoint;
                CurrentDirection = direcshen;
            }
        }
    }
    private void ClosestToPlayer()
     {
        howClose = 200;
        CheckDirecshenAndClosest(new Vector3(1, 0,0));
        CheckDirecshenAndClosest(new Vector3(-1, 0,0));
        CheckDirecshenAndClosest(new Vector3(0,0, 1));
        CheckDirecshenAndClosest(new Vector3(0,0, -1));
        Debug.Log(CurrentDirection);
    }

    private bool isAlmostZero(float a)
    {
        if (a > -0.05 && a < 0.05) return true;
        return false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, powerUpRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, sightRange);

    }
}
