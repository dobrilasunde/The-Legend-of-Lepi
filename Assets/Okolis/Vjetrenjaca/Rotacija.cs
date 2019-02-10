using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacija : MonoBehaviour {

    [SerializeField] float xRotacijaPoMinuti = 1f;
    [SerializeField] float yRotacijaPoMinuti = 1f;
    [SerializeField] float zRotacijaPoMinuti = 1f;


	// Update is called once per frame
	void Update () {
        //xStupnjeviPoOkviru = Time.deltaTime, 60, 360, xRotacijePoMinuti
        //stupnjevi okvir^-1 = sekunde okvir^-1 / sekunde minute^-1 = minute okvir^-1, 

        float xStupnjevaPoOkviru = Time.deltaTime / 60*360*xRotacijaPoMinuti;
        transform.RotateAround(transform.position, transform.right, xStupnjevaPoOkviru);

        float yStupnjevaPoOkviru = Time.deltaTime / 60 * 360 * yRotacijaPoMinuti;
        transform.RotateAround(transform.position, transform.up, yStupnjevaPoOkviru);

        float zStupnjevaPoOkviru = Time.deltaTime / 60 * 360 * zRotacijaPoMinuti;
        transform.RotateAround(transform.position, transform.forward, zStupnjevaPoOkviru);


    }
}
