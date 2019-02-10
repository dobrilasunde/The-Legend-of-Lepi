using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class TablaZivotaIgraca : MonoBehaviour
{

    RawImage slikaTableZivota;
    GospodinLijepi gospodinLijepi;

    // Use this for initialization
    void Start()
    {
        gospodinLijepi = FindObjectOfType<GospodinLijepi>();
        slikaTableZivota = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        float xVrijednost = -(gospodinLijepi.postotakZivota / 2f) - 0.5f;
        slikaTableZivota.uvRect = new Rect(xVrijednost, 0f, 0.5f, 1f);
    }
}
