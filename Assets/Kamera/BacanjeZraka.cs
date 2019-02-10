using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacanjeZraka : MonoBehaviour {

    public Sloj[] prioritetiSlojeva =
    {
        Sloj.Neprijatelj,
        Sloj.Prohodno,
        Sloj.KrajSvijeta
    };

    public float udaljenostDoPozadine = 100f;
    Camera kamera;
    RaycastHit _udara;

    public RaycastHit udara
    {
        get { return _udara; }
    }

    Sloj _udaraSloj;
    
    public Sloj udaraSloj
    {
        get { return _udaraSloj; }
    }

    public delegate void priPromjeniSloja(Sloj noviSloj);
    public event priPromjeniSloja promatraciPromjeneSloja;

 
    // Use this for initialization
    void Start () {
        kamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		
        foreach(Sloj sloj in prioritetiSlojeva)
        {
            var udar = BacanjeZrakaZaSloj(sloj);
            if(udar.HasValue)
            {
                _udara = udar.Value;
                if(_udaraSloj != sloj) //ako se promjenio sloj
                {
                    _udaraSloj = sloj;
                    promatraciPromjeneSloja(sloj);
                }
                _udaraSloj = sloj;
                return;
            }
        }

        _udara.distance = udaljenostDoPozadine;
        _udaraSloj = Sloj.KrajSvijeta;
        promatraciPromjeneSloja(udaraSloj);
	}

    RaycastHit? BacanjeZrakaZaSloj(Sloj sloj)
    {
        int maska = 1 << (int)sloj;
        Ray zraka = kamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit udar;
        bool udarioJe = Physics.Raycast(zraka, out udar, udaljenostDoPozadine, maska);
        if(udarioJe)
        {
            return udar;
        }
        return null;
    }
}
