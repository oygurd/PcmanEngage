using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
public class stopVisualWhenPickupDown : MonoBehaviour
{
     public GameObject vfx;


    // Start is called before the first frame update
    private void Start()
    {
        vfx = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "playerforportal")
        {
            // vfx.SetActive(false);
            Debug.Log("works");
            Destroy(this.gameObject);
        }
    }
}
