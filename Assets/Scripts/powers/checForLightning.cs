using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class checForLightning : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float efectDistens, timeOfEfect;
    [SerializeField] ghost_controler1 controler;
    [SerializeField] VisualEffect lightning;
    [SerializeField] Animator distortion; //activates global volume to add more effects
    private AudioSource audioSource;

    private void Start()
    {
        distortion = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    public void startChec()
    {
        Vector3 player = new Vector3(playerTransform.position.x, 0, playerTransform.position.z);
        Vector3 myPosishen = new Vector3(this.transform.position.x, 0, this.transform.position.z);
        if (Vector3.Distance(myPosishen, player) <= efectDistens)
        {
            PlaySound();
            lightning.SendEvent("onPlayBolt");
            StartCoroutine(inRech(timeOfEfect));
            distortion.SetBool("Distortion", true);
        }
        
    }
    private IEnumerator inRech(float time)
    {
        controler.stand = true;
        yield return new WaitForSeconds(time);
        controler.stand = false;
    }
    public void EndGlobalVol()//NIR
    {
        distortion.SetBool("Distortion", false);
    }


    // פונקציה זו תופעל כאשר תרצה לנגן את הסאונד
    public void PlaySound()
    {
        audioSource.Play();
    }

    /*    private void OnDrawGizmosSelected()
        {
            Vector3 myPosishen = new Vector3(this.transform.position.x, 0, this.transform.position.z);
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(myPosishen, efectDistens);
        }*/
}
