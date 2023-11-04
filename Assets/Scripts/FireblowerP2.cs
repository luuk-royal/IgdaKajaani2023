using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireblowerP2 : MonoBehaviour
{
    public float player2Counter = 0;
    private bool playerCanBlow = false;
    private float air = 0.0f;
    public Fireblower fireBlower;


    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            air += Time.deltaTime * 0.05f;
        }

        if(air > 0) { playerCanBlow = true; }
        else { playerCanBlow = false; }

        if (Input.GetKey(KeyCode.D) && playerCanBlow)
        {
            fireBlower.fireDir -= (0.01f + air / 100) / 15;
            air = Mathf.Max(0, air - Time.deltaTime * 0.204f);
        }
    }
}