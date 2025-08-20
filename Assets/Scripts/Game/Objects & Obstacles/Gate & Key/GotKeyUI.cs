using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GotKey : MonoBehaviour
{
    public KeyCollect keyCollect;
    public GateMove gateMove;
    public Image keyAppear;

    // Update is called once per frame
    void Update()
    {
        if (keyCollect.isCollect)
        {
            keyAppear.enabled = true;
        }
        if (gateMove.isGateMove)
        {
            keyAppear.enabled = false;
        }
        
    }
}
