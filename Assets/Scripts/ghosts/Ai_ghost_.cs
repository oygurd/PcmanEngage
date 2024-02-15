using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_ghost_ : MonoBehaviour
{
    [SerializeField] Vector3 movingDirecshen, size;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (checkForWay())
        {

        }
        if (checkForWall())
        {
            movingDirecshen = new Vector3(0, 0, 0);
        }
    }

    private bool checkForWall()
    {
        return Physics.BoxCast(transform.position, size, movingDirecshen);
    }
    private bool checkForWay()
    {
        return Physics.BoxCast(transform.position, size, movingDirecshen);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, size);

    }
}
