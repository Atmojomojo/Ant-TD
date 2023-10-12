using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCircle : MonoBehaviour
{
    public GameObject nutI, berryI, fireI, sprayI;

    // Start is called before the first frame update
    void Start()
    {
        nutI.SetActive(false);
        berryI.SetActive(false);
        fireI.SetActive(false);
        sprayI.SetActive(false);
    }

    public void Nut()
    {
        nutI.SetActive(true);
        berryI.SetActive(false);
        fireI.SetActive(false);
        sprayI.SetActive(false);
    }

    public void Berry()
    {
        nutI.SetActive(false);
        berryI.SetActive(true);
        fireI.SetActive(false);
        sprayI.SetActive(false);
    }

    public void Fire() 
    {
        nutI.SetActive(false);
        berryI.SetActive(false);
        fireI.SetActive(true);
        sprayI.SetActive(false);
    }

    public void Spray()
    {
        nutI.SetActive(false);
        berryI.SetActive(false);
        fireI.SetActive(false);
        sprayI.SetActive(true);
    }
}
