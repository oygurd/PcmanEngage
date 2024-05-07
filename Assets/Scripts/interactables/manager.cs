using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class manager : MonoBehaviour
{
    [SerializeField] int helf;
    public float points;
    [SerializeField] TextMeshProUGUI textPoint;
    [SerializeField] Image[] imeghelf = new Image[0];
    [SerializeField] Vector3 playerStart, ghostStart;
    [SerializeField] GameObject player, red, blue, oreng, pink;
    [SerializeField] endScrean eendScreenUI;
    private bool invonrebal;
    [SerializeField] float invonrebalFor;
    public AudioSource audioSource;

    public void AddPoints(float newPoints)
    {
        points += newPoints;
        textPoint.text = points.ToString();
        if (newPoints == 20)
        {
            PlaySound();
        }
    }

    // פונקציה זו תופעל כאשר תרצה לנגן את הסאונד
    public void PlaySound()
    {
        audioSource.Play();
    }
    // Start is called before the first frame update
    void Start()
    {
        //textHelf.text = helf.ToString();
        textPoint.text = points.ToString();
        audioSource = GetComponent<AudioSource>();
    }

    public void playerHit()
    {
        if (invonrebal)
            return;
        if (helf > 0)
        {
            helf--;
            player.transform.position = playerStart;
            red.transform.position = ghostStart;
            blue.transform.position = ghostStart;
            oreng.transform.position = ghostStart;
            pink.transform.position = ghostStart;
            imeghelf[helf].color = Color.black;
            StartCoroutine(startInvonerebal());
        }
        else
        {
            eendScreenUI.ShowEndScreen();
        }
    }

    private IEnumerator startInvonerebal()
    {
        invonrebal = true;
        yield return new WaitForSeconds(invonrebalFor);
        invonrebal = false;
    }
}