using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BacanjeZraka))]
public class Kursor : MonoBehaviour {

    [SerializeField] Texture2D kursorZaHodanje = null;
    [SerializeField] Texture2D kursorZaNapad = null;
    [SerializeField] Texture2D nepoznatiKursor = null;
    [SerializeField] Vector2 kursorHotspot = new Vector2(0, 0);

    BacanjeZraka bacanjeZraka;

	// Use this for initialization
	void Start () {
        bacanjeZraka = GetComponent<BacanjeZraka>();
        bacanjeZraka.promatraciPromjeneSloja += priPromjeniSloja;
	}
	
	// Update is called once per frame
	void priPromjeniSloja (Sloj noviSloj) {
        switch(noviSloj)
        {
            case Sloj.Prohodno:
                Cursor.SetCursor(kursorZaHodanje, kursorHotspot, CursorMode.Auto);
                break;
            case Sloj.KrajSvijeta:
                Cursor.SetCursor(nepoznatiKursor, kursorHotspot, CursorMode.Auto);
                break;
            case Sloj.Neprijatelj:
                Cursor.SetCursor(kursorZaNapad, kursorHotspot, CursorMode.Auto);
                break;
            default:
                Debug.Log("Ne znam koji kursor prikazati");
                return;

        }
            
	}
}
