using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Currency : MonoBehaviour
{
    public float currency;
    public float interest1, interest2, interest3, interest4, interest5;
    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        currency = 500;
    }

    // Update is called once per frame
    void Update()
    {
        text.SetText("$ " + currency.ToString());
    }
}
