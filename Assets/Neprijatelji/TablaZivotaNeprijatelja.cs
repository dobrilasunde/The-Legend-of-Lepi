using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TablaZivotaNeprijatelja : MonoBehaviour
{
    RawImage slikaTableZivota = null;
    Neprijatelj neprijatelj = null;

    // Use this for initialization
    void Start()
    {
        neprijatelj = GetComponentInParent<Neprijatelj>(); // Different to way player's health bar finds player
        slikaTableZivota = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        float xValue = -(neprijatelj.postotakZivota / 2f) - 0.5f;
        slikaTableZivota.uvRect = new Rect(xValue, 0f, 0.5f, 1f);
    }
}
