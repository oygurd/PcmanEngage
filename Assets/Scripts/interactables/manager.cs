using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class manager : MonoBehaviour
{
    [SerializeField] float helf;
    [SerializeField] float points;
    [SerializeField] TextMeshProUGUI textPoint, textHelf;
    [SerializeField] Vector3 playerStart, ghostStart;
    [SerializeField] GameObject player, red, blue, oreng, pink;

    public void AddPoints(float newPoints)
    {
        points += newPoints;
        textPoint.text = points.ToString();
    }

    public void AddHelf(float newHelf)
    {
        helf += newHelf;
        textHelf.text = helf.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        textHelf.text = helf.ToString();
        textPoint.text = points.ToString();
    }

    public void playerDeath()
    {
        Debug.Log("why");
        if (helf > 0)
        {
            helf--;
            textHelf.text = helf.ToString();
            player.transform.position = playerStart;
            red.transform.position = ghostStart;
            blue.transform.position = ghostStart;
            oreng.transform.position = ghostStart;
            pink.transform.position = ghostStart;
        }
        else
        {
            Debug.Log("loos");
        }
    }



    // Update is called once per frame
    void Update()
    {

    }
}