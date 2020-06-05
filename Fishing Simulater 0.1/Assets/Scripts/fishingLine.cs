using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;
using Vector3 = UnityEngine.Vector3;

public class fishingLine : MonoBehaviour
{
    public GameObject viewer;

    // Fishing rod control
    public GameObject rod;
    public GameObject bobber;
    public int rodForwardMax = 25;
    public int rodBackwardMax = -15;
    private int swing = 0;
    private int reel = 1;
    private int charge = 0;
    int lineDistance = 0;

    // Fishing line render
    public static int lineAccuracy = 100;
    private Vector3[] line = new Vector3[lineAccuracy];
    private LineRenderer lr;
    private int lrP;

    //

    /// <summary>
    /// Updates the fishing line. Does this in accordance with the destination and top of the rod.
    /// </summary>
    /// <param name="bobber">Vector3 point in space where the line should end.</param>
    /// <param name="topOfRod">Vector3 point in space where the line shoud start.</param>
    Vector3[] updateLine(Vector3 bobber, Vector3 topOfRod) {
        Vector3[] newLine = new Vector3[lineAccuracy];
        for (int i = 0; i < lrP; i++)
        {
            Debug.DrawLine(viewer.transform.position, topOfRod);
            Debug.Log(bobber);
            Debug.Log(topOfRod);
            newLine[i] = (
                new Vector3(
                    0, // Left to right
                    3.0f - (i + 1) / lrP, // Up and down
                    i / (lrP / 10) // Forward and backward
                )
            );
        }
        return newLine;
    }

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lrP = lr.positionCount;
        line = updateLine(
            bobber.transform.position, 
            new Vector3(
                rod.transform.position.x, 
                (
                    rod.transform.position.y + 
                    Convert.ToSingle(Math.Sin(rod.transform.rotation.y)) *
                    rod.GetComponentInChildren<Transform>().localScale.y
                ),
                (
                    rod.transform.position.z +
                    Convert.ToSingle(Math.Cos(rod.transform.rotation.z)) *
                    rod.GetComponentInChildren<Transform>().localScale.z
                )
            )
        );
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(swing))
        {
            // Charge the rod swing
            charge++;
        }

        if (Input.GetMouseButtonUp(swing) && charge > 0)
        {
            // Swing the rod with charge charge

            // Remove the charge
            charge = 0;
        }

        if (Input.GetMouseButton(reel) && lineDistance > 0)
        {
            // Reel the line
        }
    }
}
