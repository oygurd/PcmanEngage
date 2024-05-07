using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{
    [SerializeField] Transform portalEndLocashen;
    [SerializeField] Vector3 portalDirecshen;
    private AudioSource audioSource;

    void Start()
    {
        // אתחול ה-AudioSource וה- AudioClip
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "playerforportal")
        {
            other.transform.position = portalEndLocashen.position;
    /*        Player_Controller playerControler1 = other.GetComponent<Player_Controller>();
            playerControler1.changCurentDirecshen(portalDirecshen);*/
            input_player input = other.GetComponent<input_player>();
            input.lastinput = portalDirecshen;
            PlaySound();
        }
    }

    // פונקציה זו תופעל כאשר תרצה לנגן את הסאונד
    public void PlaySound()
    {
        audioSource.Play();
    }
}
