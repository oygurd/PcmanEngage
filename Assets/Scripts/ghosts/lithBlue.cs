using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lithBlue : MonoBehaviour
{
    [SerializeField] Transform red, playerIsh;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = ((2 * playerIsh.position) - red.position);
    }
}
