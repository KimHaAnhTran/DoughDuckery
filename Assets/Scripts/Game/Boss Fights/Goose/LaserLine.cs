using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserLine : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform firePoint;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        //enableLaser();
        disableLaser();
    }

    // Update is called once per frame
    void Update()
    {
        updateLaser();
    }

    void disableLaser()
    {
        lineRenderer.enabled = false;
    }
    void enableLaser()
    {
        lineRenderer.enabled = true;
    }
    void updateLaser()
    {
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, player.position);
    }
}
