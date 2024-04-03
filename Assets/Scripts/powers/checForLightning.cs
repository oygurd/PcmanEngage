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
   

    public void startChec()
    {
        Vector3 player = new Vector3(playerTransform.position.x, 0, playerTransform.position.z);
        Vector3 myPosishen = new Vector3(this.transform.position.x, 0, this.transform.position.z);
        if (Vector3.Distance(myPosishen, player) <= efectDistens)
        {
            distortion.SetBool("Distortion", true);
            lightning.SendEvent("onPlayBolt");
            StartCoroutine(inRech(timeOfEfect));
        }
        else
        {
            distortion.SetBool("Distortion", false);

        }
    }
    private IEnumerator inRech(float time)
    {
        controler.stand = true;
        yield return new WaitForSeconds(time);
        controler.stand = false;
    }

    /*    private void OnDrawGizmosSelected()
        {
            Vector3 myPosishen = new Vector3(this.transform.position.x, 0, this.transform.position.z);
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(myPosishen, efectDistens);
        }*/
}
