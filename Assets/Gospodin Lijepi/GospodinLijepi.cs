using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GospodinLijepi : MonoBehaviour {

    [SerializeField] float punZivot = 100f;

    float trenutnoZivota = 100f;

	public float postotakZivota
    {
        get
        {
            return trenutnoZivota / punZivot;
        }

    }
}
