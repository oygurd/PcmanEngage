using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class manager : MonoBehaviour
{
    [SerializeField] float helf;
    [SerializeField] float points;
    [SerializeField] TextMeshProUGUI textPoint, textHelf;

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
