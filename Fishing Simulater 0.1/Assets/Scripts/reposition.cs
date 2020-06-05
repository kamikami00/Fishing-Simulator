using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class reposition : MonoBehaviour
{
    public GameObject rodstick;
    public GameObject rod;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            rodstick.transform.position.x,
            rod.transform.position.y + Convert.ToSingle(Math.Sin(rod.transform.rotation.x + 0.5*Math.PI)) * rodstick.transform.localScale.y,// + Convert.ToSingle(Math.Sin(rodstick.transform.rotation.y)) * rodstick.transform.localScale.y * 2, 
                                                                                                                                // -2 * 2
            rodstick.transform.position.z// + Convert.ToSingle(Math.Cos(rodstick.transform.rotation.y)) * rodstick.transform.localScale.z
        );
        Debug.Log(rod.transform.position.y);
        Debug.Log(Convert.ToSingle(Math.Sin(rod.transform.rotation.x + 0.5 * Math.PI)));
        Debug.Log(rodstick.transform.localScale.y);
    }
}
