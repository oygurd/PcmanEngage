using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class manager : MonoBehaviour
{
    [SerializeField] int helf;
    public float points;
    [SerializeField] TextMeshProUGUI textPoint, textHelf;
    [SerializeField] Image[] imeghelf = new Image[0];
    [SerializeField] Vector3 playerStart, ghostStart;
    [SerializeField] GameObject player, red, blue, oreng, pink;
    [SerializeField] endScrean eendScreenUI;
    private bool invonrebal;
    [SerializeField] float invonrebalFor;

    public void AddPoints(float newPoints)
    {
        points += newPoints;
        textPoint.text = points.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        textHelf.text = helf.ToString();
        textPoint.text = points.ToString();
    }

    public void playerHit()
    {
        if (invonrebal)
            return;
        if (helf > 0)
        {
            helf--;
            textHelf.text = helf.ToString();
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