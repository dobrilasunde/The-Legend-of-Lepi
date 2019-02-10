using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pratiLika : MonoBehaviour {

    GameObject igrac;

	// Use this for initialization
	void Start () {
        igrac = GameObject.FindGameObjectWithTag("Player");	
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = igrac.transform.position;
	}
}
